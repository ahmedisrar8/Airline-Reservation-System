<%@ Page Title="" Language="C#" MasterPageFile="main.master" AutoEventWireup="true" CodeFile="edit_flight.aspx.cs" Inherits="edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Delay Flight - Bahria Airways</title>
    <link href="plugins/bower_components/timepicker/bootstrap-timepicker.min.css" rel="stylesheet" />
    <link href="plugins/bower_components/clockpicker/dist/jquery-clockpicker.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div class="row">
                    <div class="col-md-12">
                        <div class="white-box">
                            <h3 class="box-title">Delay Flight</h3>
                            <form class="form-horizontal" runat="server">
                                                                <div class="form-group">
                                    <label class="col-md-12">Flight Time</label>
                                    <div class="form-group col-md-4">
                                       <asp:TextBox class="form-control" ID="time1" runat="server" placeholder="hh-mm" required></asp:TextBox>                                   </div>
                                    
                                </div>
                             
                                 <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Update" OnClick="Button2_Click"/>
                                
                            </form>

                        </div>
                    </div>
                </div>
    <script src="plugins/bower_components/clockpicker/dist/jquery-clockpicker.min.js"></script>
    <script src="plugins/bower_components/timepicker/bootstrap-timepicker.min.js"></script>
    <script>
        jQuery('.form-control,#single-input').clockpicker({
            placement: 'bottom',
            align: 'left',
            autoclose: true,
            'default': 'now'
        });
    </script>
</asp:Content>

