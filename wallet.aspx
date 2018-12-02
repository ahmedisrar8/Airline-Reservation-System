<%@ Page Title="" Language="C#" MasterPageFile="main.master" AutoEventWireup="true" CodeFile="wallet.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>My Wallet - Bahria Airways</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
            <div class="container-fluid">
                <div class="row bg-title">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Wallet</h4> </div>
                    <%--  --%>
                    <!-- /.col-lg-12 -->
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="white-box">
                            <h3 class="box-title"> </h3> 
<div class="row">
                  
                    <div class="col-md-12">
                        <div class="white-box bg-success m-b-15">
                            <h3 class="box-title text-white">Wallet</h3>
                            <div class="row">
                                <div class="col-md-2">
                                    <h1 class="text-white">PKR <% Response.Write(bal); %></h1>
                                    <p class="light_op_text">Deposit More</p></div>
                            </div>
                        </div>
                        <form runat="server" class="form-horizontal">
                    
                                                   <div class="form-group">
                                  
                                    <div class="col-md-2">
                                       <asp:TextBox class="form-control" ID="t" runat="server"   required placeholder="Deposit Amount"></asp:TextBox> 

                                    </div>
                                </div>
          <% if (stat == "D")
              { %>
                                <div class="form-group">
                                  
                                    <div class="col-md-3">
                                       <asp:TextBox class="form-control" ID="cardn" runat="server" MaxLength="19"   required placeholder="Enter 19 Digits Card Number"></asp:TextBox> 

                                    </div>
                                </div>
               <div class="form-group">
                                
                                    <div class="col-md-2">
                                       <asp:TextBox class="form-control" ID="cvc" runat="server" MaxLength="3"   required placeholder="CVC"></asp:TextBox> 

                                    </div>
                     <div class="col-md-2">
                                       <asp:TextBox class="form-control" ID="ex" runat="server"  required placeholder="MM/YY"></asp:TextBox> 

                                    </div>
                                </div>

                                 <%} %>
  <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Deposit" OnClick="Button2_Click"/>

                              
                                    </form>
                    </div>
      
                
                </div>
                        </div>

                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
          
        <!-- /#page-wrapper -->
</asp:Content>

