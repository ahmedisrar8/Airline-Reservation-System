<%@ Page Title="" Language="C#" MasterPageFile="main.master" AutoEventWireup="true" CodeFile="b_flight.aspx.cs" Inherits="pixeladmin_lite_html_b_flight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Book a Flight - Bahria Airways</title>
    <link href=" plugins/bower_components/jquery-wizard-master/css/wizard.css" rel="stylesheet">
      <link rel="stylesheet" href=" plugins/bower_components/jquery-wizard-master/libs/formvalidation/formValidation.min.css">
    <link href="plugins/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
                    <div class="col-md-12">
                        <div class="white-box">
                            <h3 class="box-title">Book a  Flight</h3>
                                <form runat="server" class="form-horizontal">
                                         <div class="form-group">
          <div class="col-md-12">
            <small id="error" runat="server" style="color:red;"></small>
             
          </div>
        </div>
                                                                            <div class="form-group">
                                    <label class="col-md-12">Departing On</label>
                                    <div class="col-md-4">
                                       <asp:TextBox class="form-control mydatepicker" ID="date1" runat="server" placeholder="yyyy-mm-dd" required></asp:TextBox> 

                                    </div>
                                </div>
                                     <div class="form-group">
                                   
                                    <div class="col-md-4">
                                         <b>From</b>               
                                      <select class="form-control" runat="server" id="dept" >
                                            <option value="AR-KHI-001">Karachi (KHI)</option>
                                            <option value="AR-ISL-001">Islamabad (ISL)</option>
                                          <option value="AR-LHR-001">Lahore (LHR)</option>
                                        </select>

                                    </div>

                                          <div class="col-md-4">
                                         <b>To</b>
                                               <select class="form-control" runat="server" id="arri" >
                                               <option value="AR-ISL-001">Islamabad (ISL)</option>
                                            <option value="AR-KHI-001">Karachi (KHI)</option>
                                             <option value="AR-LHR-001">Lahore (LHR)</option>   
                                        </select>

                                    </div>
                                </div> 
                                         <div class="form-group">
                                    <label class="col-md-12">Cabin</label>
                                    <div class="col-md-4">
                                      <select class="form-control" runat="server" id="Cabin" >
                                            <option>Economy</option>
                                            <option>Business</option>
                                            
                                        </select>

                                    </div>
                                </div>
                                             <div class="form-group">
                                    <label class="col-md-12">Adults</label>
                                    <div class="col-md-4">
                                      <select class="form-control" id="Adult" runat="server">
                                            <option>1</option>
                                            <option>2</option>
                                           <option>3</option>
                                           <option>4</option>
                                           <option>5</option>
                                           <option>6</option>
                                            
                                        </select>

                                    </div>
                                                                                     <label class="col-md-12">Children</label>
                                    <div class="col-md-4">
                                      <select class="form-control" id="Child" runat="server">
                                           <option>none</option>
                                           <option>1</option>
                                            <option>2</option>
                                           <option>3</option>
                                           <option>4</option>
                                           <option>5</option>
                                            
                                        </select>

                                    </div>                                    <label class="col-md-12">Infants</label>
                                    <div class="col-md-4">
                                      <select class="form-control" id="Infant" runat="server">
                                          <option>none</option>
                                           <option>1</option>
                                            <option>2</option>
                                        </select>
                                    </div>
                                                 </div>
  <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Find Flights" OnClick="Button2_Click"/>

                              
                                    </form>
                            </div>

                    </div>
                </div>

     <script src=" plugins/bower_components/jquery-wizard-master/dist/jquery-wizard.min.js"></script>
    <script src=" plugins/bower_components/jquery-wizard-master/libs/formvalidation/formValidation.min.js"></script>
    <script src=" plugins/bower_components/jquery-wizard-master/libs/formvalidation/bootstrap.min.js"></script>
        <script src="plugins/bower_components/bootstrap-select/bootstrap-select.min.js"></script>
    <script src="plugins/bower_components/footable/js/footable.all.min.js"></script>
     <script src="plugins/bower_components/clockpicker/dist/jquery-clockpicker.min.js"></script>
    <script src="plugins/bower_components/bootstrap-datepicker/bootstrap-datepicker.min.js"></script>
    <script>
        jQuery('#exampleBasic').wizard({
            onFinish: function () {
                alert('finish');
            }
        });
        var dateToday = new Date();

        jQuery('.mydatepicker, #datepicker').datepicker({
            dateFormat: 'yy-mm-dd',
            autoclose: true,
            todayHighlight: true,
            format: 'yyyy-mm-dd',


            // appendText: "(yyyy-mm-dd)"
        });
    
    </script>
</asp:Content>

