<%@ Page Title="" Language="C#" MasterPageFile="main.master" AutoEventWireup="true" CodeFile="ticket.aspx.cs" Inherits="ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
                    <div class="col-md-12">
                        <div class="white-box">
                            <h3><b>Ticket</b> <span class="pull-right">#<%Response.Write(t_no.ToUpper());%></span></h3>
                            <hr>
                            <div class="row">

                                <div class="col-md-12">
                                    <h3> &nbsp;<span  class="fa fa-2x fa-anchor">&nbsp;</span><b>BAHRIA</b>IRWAYS</h3>
                                    <%if (msg != "yes")
                                        { %>
                                     <p class="m-t-30"><i class="fa fa-bell">&nbsp;&nbsp;</i>This booking will expire on <% Response.Write(b_e_date);%></p>
                                   <% } %>
                                     <div class="pull-left text-left">
                                        <address>
                                            
                                            <h3>From</h3>
                                            <h4 class="font-bold text-dark"><% Response.Write(dloc);%>,</h4>
                                            <p class="text-muted m-l-30">
                                                <b><% Response.Write(dtime);%> Departure</b>
                                            </p>
                                            <p class="m-t-30"><b>Dep Date :</b> <i class="fa fa-calendar">&nbsp;</i><% Response.Write(ddate);%></p>
                                         <p class="m-t-30"><b>Booking Date :</b> <i class="fa fa-calendar">&nbsp;</i><% Response.Write(b_date);%></p>
                                        </address>

                                    </div>
                                          <div class="pull-left text-left">
                                        <address>
                                            
                                            <h3>To</h3>
                                            <h4 class="font-bold text-success"><% Response.Write(aloc);%>,</h4>
                                            <p class="text-muted m-l-30">
                                                <b><% Response.Write(atime);%> Arrival</b>
                                                
                                            </p>
                                        </address>

                                    </div>
                                    <div class="pull-left text-left"  style="margin-left:30px ;padding-left:10px ; border-left:2px solid #808080">
                                        <address>
                                            
                                            <h3>Flight Number</h3>
                                            <h4 class="font-bold text-warning"><%Response.Write(f_no.ToUpper());%>,
                                            </h4>
                                            <h4>&nbsp;&nbsp;</h4>
                                            </address>

                                    </div>
                                </div>
                               
                                <div class="col-md-12">
                                    <div class="table-responsive m-t-40">
                                         <h3><b>Travellers Details</b></h3>
                                        <hr />
                                        <table class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">#</th>
                                                    <th>Name</th>
                                                    <th class="text-right">Contact</th>
                                                    <th class="text-right">Seat</th>
                                                    <th class="text-right">Fare</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                  <% Response.Write(data); %>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                       <div class="col-md-12">
                                    <div class="table-responsive m-t-40">
                                         <h3><b>Refund Or Change Policy</b></h3>
                                        <hr />
                                        <table class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th>Change Fees</th>
                                                    <th>Cancel Fees</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td><b class="text-success">PKR 2,500</b> within 48 hours of departure<br />
<b class="text-success">PKR 1,500</b> more than 48 hours before departure</td>
                                                    <td><b class="text-success">PKR 2,500</b> within 48 hours of departure<br />
<b class="text-success">PKR 1,500</b> more than 48 hours before departure</td>
                                                   
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="pull-right m-t-30 text-right">
                                        <hr/>
                                        <h3><b>Total :</b> PKR <% Response.Write(total); %></h3>
                                    </div>
                                    <div class="clearfix"></div>
                                    <hr>
                                    <div class="text-right">
                                        <form runat="server">
                                            <asp:Button class="btn btn-danger" ID="Button1" runat="server" Text="Make Payment" OnClick="Button1_Click"  />
                                            </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>

