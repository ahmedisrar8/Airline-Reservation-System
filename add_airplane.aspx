<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="add_airplane.aspx.cs" Inherits="add_airplane" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Add Airlines - Bahria Airways</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
                <div class="row bg-title">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Add Airplane</h4> </div>
                    <%--  --%>
                    <!-- /.col-lg-12 -->
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="white-box">
                            <h3 class="box-title">Add Airplane</h3> 
                            <p class="text-muted m-b-30 font-13">Please fill all the fields carefully</p>
                            <form class="form-horizontal" runat="server">
                                 
                                
                                <div class="form-group">
                                    <label class="col-md-12">Plane Model & Year</label>
                                    <div class="col-md-12">
                                        <input type="text" class="form-control"  placeholder=' e.g. "Boeing 777-1990"'> </div>
                                </div>
                                   <div class="form-group">
                                    <label class="col-md-12">Economy Class Capacity</label>
                                    <div class="col-md-12">
                                        <input type="number" class="form-control" min="0"> </div>
                                </div>
                                 <div class="form-group">
                                    <label class="col-md-12">Business Class Capacity</label>
                                    <div class="col-md-12">
                                        <input type="number" class="form-control" min="0"> </div>
                                </div>
                                
                                <asp:Button ID="Button1"  style="font-style:normal ; height:35px; border-radius: 0 ; padding:0" class="btn btn-success waves-effect waves-light m-r-10"  runat="server" Text="Submit" OnClick="Button1_Click" />
                                <button type="reset" class="btn btn-inverse waves-effect waves-light">Cancel</button>
                                </form>
                        </div>
                      
                               
                                
                           

                    </div>
                </div>
            </div>
</asp:Content>

