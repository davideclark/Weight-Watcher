<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.WeightRecord>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Weight Details</legend>
        
        <div class="display-label"><strong>Weight</strong></div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Weight) %></div>
        
        <div class="display-label"><strong>Date</strong> </div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Date) %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.WeightRecordID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

