<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StepsTimeline.ascx.cs" Inherits="RockWeb.Plugins.org_abwe.RockMissions.StepsTimeline" %>

<style>
.panel-fullwidth {
    margin: -15px -15px 0 -15px;
}

.swimlanes .grid-background {
  fill: none; }

.swimlanes .grid-header {
  fill: #f7f7f7;
  stroke: #e5e5e5;
  stroke-width: .3; }

.swimlanes .grid-row {
  fill: #fff; }

.swimlanes .grid-row:nth-child(even) {
  fill: #f9f9f9; }

.swimlanes .row-line {
  stroke: #e5e5e5; }

.swimlanes .tick {
  stroke: #939393;
  stroke-width: .2; }
  .swimlanes .tick.thick {
    stroke-width: .4; }

.swimlanes .today-highlight {
  opacity: .5;
  fill: #fcf8e3; }

.swimlanes .bar {
  user-select: none;
  transition: stroke-width .3s ease;
  fill: #b8c2cc;
  stroke: #8d99a6;
  stroke-width: 0;
  opacity: 0.8;
}

.swimlanes .bar-invalid {
  fill: transparent;
  stroke: #8d99a6;
  stroke-width: 1;
  stroke-dasharray: 5; }
  .swimlanes .bar-invalid ~ .bar-label {
    fill: white; }

.swimlanes .bar-label {
  font-size: 12px;
  font-weight: 400;
  fill: white;
  dominant-baseline: central;
  text-anchor: middle; }
  .swimlanes .bar-label.big {
    fill: #555;
    text-anchor: start; }

.swimlanes .bar-wrapper {
  cursor: pointer; }
  .swimlanes .bar-wrapper:hover .bar, .swimlanes .bar-wrapper.active .bar {
    stroke-width: 2;
    opacity: .8; }
  .swimlanes .bar-wrapper.is-leader .bar {
    opacity: 1; }

.swimlanes .lower-text,
.swimlanes .upper-text {
  font-size: 14px;
  text-anchor: middle; }

.swimlanes .upper-text {
  font-weight: 800;
  fill: #555; }

.swimlanes .lower-text {
  font-size: 12px;
  fill: #333; }

.swimlanes .hide {
  display: none; }

.gantt-container {
  position: relative;
  overflow: scroll;
  font-size: 12px; }
  .gantt-container .popup-wrapper {
    position: absolute;
    top: 0;
    left: 0;
    padding: 0;
    color: #959da5;
    background: rgba(0, 0, 0, 0.8);
    border-radius: 3px; }
    .gantt-container .popup-wrapper .title {
      padding: 10px;
      border-bottom: 1px solid #fff; }
      .gantt-container .popup-wrapper .title a {
        color: #fff;
        font-size: 16px; }
    .gantt-container .popup-wrapper .subtitle {
      padding: 10px;
      color: #dfe2e5; }
    .gantt-container .popup-wrapper .pointer {
      position: absolute;
      height: 5px;
      margin: 0 0 0 -5px;
      border: 5px solid transparent;
      border-top-color: rgba(0, 0, 0, 0.8); }

</style>

<script src="<%=this.RockPage.ResolveRockUrl("/Plugins/org_abwe/RockMissions/Scripts/frappe-gantt.min.js", true) %>"></script>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfPersonId" runat="server" />
        <asp:HiddenField ID="hfStepTypeIds" runat="server" />
        <asp:HiddenField ID="hfStepDetailsUrl" runat="server" />

        <div class="panel panel-block">
            <div class="panel-heading">
                <h1 class="panel-title">
                    <i class="fa fa-history"></i>
                    Timelines
                </h1>

                <a class="btn btn-xs btn-default pull-right margin-l-sm" onclick="javascript: toggleOptions()">
                    <i title="Options" class="fa fa-gear"></i>
                </a>

                <div class="btn-group btn-group-xs margin-l-sm hidden-xs" role="group" aria-label="...">
                    <button type="button" class="btn btn-default" onclick="gantt.change_view_mode('Week')">Week</button>
                    <button type="button" class="btn btn-default" onclick="gantt.change_view_mode('Month')">Month</button>
                    <button type="button" class="btn btn-default" onclick="gantt.change_view_mode('Year')">Year</button>
                </div>

                <!-- Single button -->
                <div class="btn-group">
                  <button type="button" class="btn btn-default dropdown-toggle btn-xs margin-l-sm" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="fa fa-plus"></i> <span class="caret"></span>
                  </button>
                    
                  <ul class="dropdown-menu dropdown-menu-right">
                      <asp:Repeater runat="server" ID="ddAddStep">
                          <ItemTemplate>
                              <li><a href="#" onclick="__doPostBack('LoadStepDetails','<%# Eval("Id") %>,0')"><%# Eval("Name") %></a></li>
                          </ItemTemplate>
                      </asp:Repeater>
                  </ul>
                </div>
            </div>

            <asp:Panel ID="pnlOptions" runat="server" Title="Options" CssClass="panel-body js-options" Style="display: none">
                <div class="row">
                    <div class="col-md-6">
                        <Rock:RockCheckBoxList ID="cblStepTypes" Label="Types" runat="server" />
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>

                <div class="actions">
                    <asp:LinkButton ID="btnApplyOptions" runat="server" Text="Apply" CssClass="btn btn-primary btn-xs" OnClick="btnApplyOptions_Click" />
                </div>
            </asp:Panel>

            <div class="panel-body">
                <div class="js-no-group-history" style="display:none">
                    <Rock:NotificationBox ID="nbNoGroupHistoryFound" runat="server" NotificationBoxType="Info" Text="No Group History Available" />
                </div>
                 <asp:Panel ID="groupHistorySwimlanes" CssClass="panel-fullwidth" runat="server" />

                <div class="grouptype-legend">
                    <label>Timelines</label>
                    <div class="grouptype-legend">
                        <asp:Repeater ID="rptStepTypeLegend" runat="server" OnItemDataBound="rptStepTypeLegend_ItemDataBound">
                            <ItemTemplate>
                                <span class="padding-r-sm">
                                    <asp:Literal ID="lStepTypeBadgeHtml" runat="server" /></span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Literal ID="lStepTimeLegend" runat="server" />
                </div>
            </div>
        </div>

        <script type="text/javascript">
            var currentMousePos = { x: -1, y: -1 };

            function toggleOptions() {
                $('.js-options').slideToggle();
            }

            function getStepTitle(step) {
                switch (step.StepType.Guid) {
                    case 'ff3e7f7f-4127-4a95-8990-2eecf2cc7c03': // Field Assignment
                        return `${step.AttributeValues["Details"].ValueFormatted}`;

                    case '7aae4cbb-9058-4beb-968b-4c0d9c92b4ef': // Appointment
                        return `${step.AttributeValues["Commitment"].ValueFormatted} ${step.AttributeValues["Length"].ValueFormatted} ${step.AttributeValues["Associate"].Value == "True" ? "Associate" : ""}`;

                    default:
                        return `${step.StepType.Name}`;
                }
            }

            Sys.Application.add_load(function () {

                var restUrl = '<%=ResolveUrl( "~/api/Steps?$expand=StepType%2C%20StepType%2FStepProgram&$orderby=StepType%2FStepProgram%2FOrder%2C%20StepType%2FOrder%2C%20StartDateTime%20desc&loadAttributes=simple&$filter=" ) %>'

                var filterParams = [];
                var personAliasId = $('#<%=hfPersonId.ClientID%>').val();
                var stepTypeIds = $('#<%=hfStepTypeIds.ClientID%>').val();

                filterParams.push(`PersonAliasId eq ${personAliasId}`);

                if (stepTypeIds && stepTypeIds != '') {
                    var stepIdFilters = stepTypeIds.split(',').map((stepId) => `StepTypeId eq ${stepId}`);
                    filterParams.push('(' + stepIdFilters.join(' or ') + ')');
                }

                var $swimlanesContainer = $('#<%=groupHistorySwimlanes.ClientID%>');
                var $noGroupHistory = $('.js-no-group-history');

                $swimlanesContainer.append("<svg id='gantt' class='swimlanes'></svg>");

                $.ajax({
                    url: restUrl + filterParams.join(' and '),
                    dataType: 'json',
                    contentType: 'application/json'
                }).done(function (data) {
                    var steps = data.map(step => ({
                        id: step.Id,
                        name: getStepTitle(step),
                        start: step.StartDateTime,
                        end: step.EndDateTime || step.CompletedDateTime,
                        Color: step.StepType.HighlightColor,
                        data: step
                    }));

                    window.gantt = new Gantt("#gantt", steps, {
                        on_click: function (task) {
                            console.log(task);
                            __doPostBack('LoadStepDetails', task.data.StepType.Id + ',' + task.data.Id);
                        }
                    });

                    gantt.change_view_mode('Year');
                });


                $(document).mousemove(function(e) {
                        currentMousePos.x = e.pageX - $('#<%=groupHistorySwimlanes.ClientID%> .gantt-container').offset().left + $('#<%=groupHistorySwimlanes.ClientID%> .gantt-container').scrollLeft(),
                        currentMousePos.y = e.pageY + $('#<%=groupHistorySwimlanes.ClientID%> .gantt-container').scrollTop()
                });
            });


        </script>
    </ContentTemplate>
</asp:UpdatePanel>
