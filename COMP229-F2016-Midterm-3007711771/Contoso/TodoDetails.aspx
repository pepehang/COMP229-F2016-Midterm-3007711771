<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP229_F2016_Midterm_3007711771.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Add a thing</h1>
                <h5>All Fields are required</h5>
                <br />

                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Descirption</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="LastNameTextBox" 
                        placeholder="Desciprtion" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="FirstNameTextBox">Note</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="FirstNameTextBox" 
                        placeholder="Note" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="EnrollmentDateTextBox">Completed</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="EnrollmentDateTextBox" 
                        placeholder="Completed" required="true"></asp:TextBox>
                </div>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
                        OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
