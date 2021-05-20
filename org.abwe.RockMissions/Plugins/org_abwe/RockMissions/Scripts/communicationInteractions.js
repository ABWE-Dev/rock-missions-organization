
// Listen for postbacks on the communciations UI with the aim of
// adding "Add as interaction" functionality to the end of a communication wizard

var interactionComponents = null;
$.post("/api/Lava/RenderTemplate", `{% interactionchannel where:'Guid == "D1853AE1-145F-4AE1-84CF-E7F62024B121"' %}{% assign interactionchannel = interactionchannelItems | First %}{% endinteractionchannel %}[{% interactioncomponent where:'InteractionChannelId == {{interactionchannel.Id}}' %}{% for component in interactioncomponentItems %}{ "Name" : "{{ component.Name }}", "Guid" : "{{ component.Guid }}" }{% if forloop.last == false %},{% endif %}{% endfor %}{% endinteractioncomponent %}]`, function (results) {
    interactionComponents = JSON.parse(results);
});

var interactionCategories = null;
$.get("/api/Categories?$filter=EntityTypeId%20eq%20576&$select=Guid%2C%20Name", function (results) {
    interactionCategories = results;
});

var observer = new MutationObserver(function(mutations) {
    // There is a different result panel for the simple communication block and communication wizard
    // If this is the results page, add the "Add as interaction" buttons with possible values
    let el = document.querySelector('div[id$=pnlResult]') || document.querySelector('div[id$=pnlTaskResult]>.panel-body')
    if (el) {
        if (document.querySelector('.add-interactions')) return;
    
        let baseDiv = $('<div class="add-interactions" style="margin-top: 20px;"></div>');
        let postInteraction = $('<div></div>');
        let additionalOptions = $('<div></div>');
        let spanLabel = $('<span>Save to interactions:</span>');
        let saveButton = $('<button class="btn btn-primary">Save</button>');
        let categorySelect = $('<select class="interaction-categories"></select>');
        postInteraction.append(spanLabel);
        
        for (let interactionComponent of interactionComponents) {
            postInteraction.append('<label style="margin-left: 20px;margin-right: 20px;display: inline-block;"><input type="checkbox" value="'+interactionComponent.Guid+'" checked="true"/> '+interactionComponent.Name+'</label>');
        }

        for (let category of interactionCategories) {
            categorySelect.append(`<option value="${category.Guid}">${category.Name}</option>`);
        }

        additionalOptions.append($('<a href="#interactionCategoryPicker" class="collapser collapsed" data-toggle="collapse"><i class="fa fa-caret-down"></i> Category</a>'));
        additionalOptions.append($("<div class='collapse' id='interactionCategoryPicker'></div>").append(categorySelect));

        additionalOptions.append(`<a href="#interactionUTM" data-toggle="collapse" class="collapser collapsed"><i class="fa fa-caret-down"></i> UTM</a>
        <div class="collapse" id="interactionUTM">
            <div><label style="width: 100px;">Source:</label> <input type="text" id="interactionUTMsource" /></div>
            <div><label style="width: 100px;">Medium:</label> <input type="text" id="interactionUTMmedium" /></div>
            <div><label style="width: 100px;">Campaign:</label> <input type="text" id="interactionUTMcampaign" /></div>
        </div>`);

        saveButton.on('click',function (event) {
            saveButton.prop('disabled', true);

            let guids = [];
            baseDiv.find('input:checked').each(function () {
                guids.push($(this).val());
            });

            let categoryGuid = categorySelect.val();
            let communicationId = document.querySelector('a[id$=hlViewCommunication]').href.split("CommunicationId=")[1];
            let source = document.querySelector("#interactionUTMsource").value;
            let medium = document.querySelector("#interactionUTMmedium").value;
            let campaign = document.querySelector("#interactionUTMcampaign").value;
            
            event.stopImmediatePropagation();
            event.preventDefault();

            $.get("/api/WorkflowTypes?$filter=Guid%20eq%20guid'ead317e1-4546-41be-bcf6-82bd6130c2b4'&$select=Id", function (results) {
                let workflow = results[0].Id;
                $.post(`/api/Workflows/WorkflowEntry/${workflow}?VisibleTo=${guids.join(',')}&CommunicationId=${communicationId}&Source=${source}&Medium=${medium}&Campaign=${campaign}&Category=${categoryGuid}`, function (result) {
                    saveButton.toggleClass('btn-default');
                    saveButton.toggleClass('btn-success');
                    saveButton.html('<i class="fa fa-check"></i> Saved');
                });
            })

        });
        postInteraction.append(saveButton);

        baseDiv.append(postInteraction);
        baseDiv.append(additionalOptions);
        baseDiv.insertAfter(el);
        $('<hr>').insertAfter(el);
    }
});
    
var observerConfig = {
    attributes: true, 
    childList: true,
};

var targetNode = document.querySelector('form');
observer.observe(targetNode, observerConfig);