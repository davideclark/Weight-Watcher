<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.PaginatedList<MvcApplication1.Models.WeightRecord>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Weights</h2>
      <div style="position:absolute; margin-left:0px;margin-bottom:0px;"> 
      <% if (Model.HasPreviousPage)
      { %>

      <%: Html.RouteLink("<<<", "PagedWeight", new { page = (Model.PageIndex - 1) })%>

    <%} %>
    </div>
    
    <div style="position:absolute; margin-left:30px">
    <%if (Model.HasNextPage)
      { %>

      <%: Html.RouteLink(">>>", "PagedWeight", new { page = (Model.PageIndex + 1) })%>

    <%} %>
    </div>
    <br />
    <br />
    <table>
        <tr>
            <th></th>
            <th>
            <%: Html.ActionLink("Weight", "Index", new { sort = "weight" })%>
                
            </th>
            <th>
                Date
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
        
            <td>

            <h1> </h1>
            <button id="opener<%: String.Format("{0:#}", item.WeightRecordID) %>">Open the dialog</button> 
       
                <%: Html.ActionLink("Edit", "Edit", new { id = item.WeightRecordID })%> |
                <%: Html.ActionLink("Details", "Details", new { id=item.WeightRecordID  })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.WeightRecordID })%>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Weight) %>
            </td>
            <td>
                <%: String.Format("{0:D}", item.Date) %>
            </td>
        </tr>
    
    <% } %>

    </table>

  

  






    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <div class="demo">

<div id="dialog" title="Basic dialog">
	<p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
</div>

<!-- Sample page content to illustrate the layering of the dialog -->
<div class="hiddenInViewSource" style="padding:20px;">
<p>Sed vel diam id libero <a href="http://example.com">rutrum convallis</a>. Donec aliquet leo vel magna. Phasellus rhoncus faucibus ante. Etiam bibendum, enim faucibus aliquet rhoncus, arcu felis ultricies neque, sit amet auctor elit eros a lectus.</p>
<form>
	<input value="text input" /><br />
	<input type="checkbox" />checkbox<br />
	<input type="radio" />radio<br />
	<select>
		<option>select</option>
	</select><br /><br />
	<textarea>textarea</textarea><br />
</form>
</div><!-- End sample page content -->

</div><!-- End demo -->
    <script>
        // increase the default animation speed to exaggerate the effect
        $.fx.speeds._default = 1000;
        $(function () {
            $("#dialog").dialog({
                autoOpen: false,
                show: "blind",
                hide: "explode"
            });

            $("#opener10").click(function () {
                $("#dialog").dialog("open");
                return false;
            });
        });
	</script>



</asp:Content>

