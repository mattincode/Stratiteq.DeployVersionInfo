<%@ Page Title="GSP Versioner" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stratiteq.DeployVersionInfo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">

        <h1>GSP Versioner</h1>
        <asp:DataList ID="VersionList" runat="server" Font-Size="11" Width="100%">

            <HeaderTemplate>
                <div class="row">
                  <div class="col-md-3">
                    <asp:Label Text='Site' Font-Bold="True" Runat="Server"/>    
                  </div>
                  <div class="col-md-3"> 
                    <asp:Label Text='Deploydatum' Font-Bold="True" Runat="Server"/>    
                  </div>
                  <div class="col-md-2"> 
                   <asp:Label Text='Version' Font-Bold="True" Runat="Server"/>    
                  </div>
                  <div class="col-md-4"> 
                    <asp:Label Text='Byggtidpunkt' Font-Bold="True" Runat="Server"/>    
                  </div>
                </div>
            </HeaderTemplate>
<%--            <SeparatorTemplate>
                </div><div>
            </SeparatorTemplate>--%>
            <ItemTemplate>
                <div class="row">
                  <div class="col-md-3">
                    <asp:Label Text='<%# Eval("SiteName") %>' Font-Size="11" Runat="Server" ToolTip='<%# Eval("ToolTip") %>'/>    
                  </div>
                  <div class="col-md-3"> 
                    <asp:Label Text='<%# Eval("UpdatedOn") %>' Runat="Server"/>    
                  </div>
                  <div class="col-md-2"> 
                   <asp:Label Text='<%# Eval("Version.Version") %>' Runat="Server"/>    
                  </div>
                  <div class="col-md-4"> 
                    <asp:Label Text='<%# Eval("Version.BuildTimeText") %>' Runat="Server"/>    
                  </div>
                </div>
                            
            </ItemTemplate>
<%--            <FooterTemplate>
                </div>
            </FooterTemplate>--%>
        </asp:DataList>
    </div>


</asp:Content>
