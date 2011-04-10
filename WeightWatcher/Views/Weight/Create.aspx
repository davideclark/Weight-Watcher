<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.WeightRecord>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Weight) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Weight) %>
                <%: Html.ValidationMessageFor(model => model.Weight) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Date) %>
                <%: Html.ValidationMessageFor(model => model.Date) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

