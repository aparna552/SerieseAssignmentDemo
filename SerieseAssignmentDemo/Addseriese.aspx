<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addseriese.aspx.cs" Inherits="SerieseAssignmentDemo.Addseriese" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <!-- Bootstrap CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
<!-- Bootstrap JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet" />
        <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet"/>
    <title>Add or Update Series</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="msg" runat="server" ></asp:Label>
        </div>
       <div class="container mt-5">
           
            <div class="card">
                <div class="card-header bg-primary text-white text-center">
                    <h4 id="lblTitle" runat="server">Add or Update Series</h4>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                       
                        <div class="col-md-4">
                            <label for="txtSeriesName" class="form-label">Series Name:</label>
                            <asp:TextBox ID="txtSeriesName" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label for="ddlSeriesType" class="form-label" >Series Type:</label>
                            <asp:DropDownList ID="ddlSeriesType" runat="server" CssClass="form-select" DataValueField="SeriesType" DataTextField="SeriesType">
                                <asp:ListItem Text="Select" Value="" />
                               
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="ddlMatchType" class="form-label">Match Type:</label>
                            <asp:DropDownList ID="ddlMatchType" runat="server" CssClass="form-select" DataValueField="MatchType" DataTextField="MatchType">
                                <asp:ListItem Text="Select" Value="" />
                                
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row g-3 mt-3">
                        
                        <div class="col-md-4">
                            <label for="ddlGender" class="form-label">Gender:</label>
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select" DataValueField="Gender" DataTextField="Gender">
                                <asp:ListItem Text="Select" Value="" />
                               
                            
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="txtYear" class="form-label">Year:</label>
                            <asp:TextBox ID="txtYear" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtTrophyType" class="form-label">Trophy Type:</label>
                            <asp:TextBox ID="txtTrophyType" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="row g-3 mt-3">
                        
                        <div class="col-md-6">
                            <label for="txtStartDate" class="form-label">Series Start Date:</label>
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date" />
                        </div>
                        <div class="col-md-6">
                            <label for="txtEndDate" class="form-label">Series End Date:</label>
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date" />
                        </div>
                    </div>
                </div>
                <div class="card-footer text-center">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success px-4" Text="Save" OnClick="btnSave_Click"  />
                 
                      
                
                </div>
            </div>
           <div class="card">

           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="SeriesEID" OnRowEditing="GridView1_RowEditing"

    OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
    CssClass="table table-striped table-bordered">
    <Columns>
      
        <asp:BoundField DataField="SeriesEID" HeaderText="ID" ReadOnly="True" />
        
      
        <asp:BoundField DataField="SeriesName" HeaderText="Series Name" />
        <asp:BoundField DataField="SeriesType" HeaderText="Series Type" />
        <asp:BoundField DataField="MatchType" HeaderText="Match Type" />
        <asp:BoundField DataField="Gender" HeaderText="Gender" />
        <asp:BoundField DataField="Year" HeaderText="Year" />
        <asp:BoundField DataField="TrophyType" HeaderText="Trophy Type" />
        <asp:BoundField DataField="SeriesStartDate" HeaderText="Start Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="SeriesEndDate" HeaderText="End Date" DataFormatString="{0:yyyy-MM-dd}" />
        

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button"   />
    </Columns>
    <RowStyle BackColor="#EFF3FB" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
</asp:GridView>

           </div>


        </div>  

    </form>
</body>
</html>
