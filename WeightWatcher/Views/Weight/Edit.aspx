<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.WeightRecord>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>


    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            


            <div class="editor-label">
                <%: Html.LabelFor(model => model.Weight) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Weight, String.Format("{0:F}", Model.Weight)) %>
                <%: Html.ValidationMessageFor(model => model.Weight) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Date) %>
            </div>
            <%--model => model.Date, String.Format("{0:D}", Model.Date--%>
            <div class="editor-field">

                <%: Html.TextBoxFor(model => model.Date, String.Format("{0:D}", Model.Date)) %>
                

      </div>

            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
    <p>Date: <input type="text" id="date2"/></p>
  
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


    	<script type="text/javascript">
    	    $(function () {
    	        var date_stripped_of_time = $("#Date").val().substring(0, 10);
    	        $("#Date").val(date_stripped_of_time);

    	        $("#Date").datepicker({
                       dateFormat: 'dd/mm/yy'
                    });
    	    });


	</script>
</asp:Content>

