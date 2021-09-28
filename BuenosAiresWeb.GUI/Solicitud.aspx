<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="BuenosAiresWeb.GUI.Solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"></script>
        <script src="js/sweetAlert.js" ></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
        <script src="sweetalert2.all.min.js"></script>
    <script>
        function Solicitud() {
            Swal.fire({
                icon: 'success',
                title: 'Solicitud enviada',
                text: 'Se enviará la confirmación a tu correo!'
            });
        }
    </script>
    <br />
    <div class="container" style="border:1px solid gainsboro; width:90%">
        <br />
        <h5>Solicitud de servicio</h5>
        <br />
        <div class="form-row">
            <div class="form-group col">
              <label >Nombres</label>
                <asp:TextBox type="Input" class="form-control" ID="TxtNombres" runat="server" sstyle="height:35px; width:80px; margin-left:15px"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtNombres" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col">
              <label >Apellidos</label>
                <asp:TextBox type="Input" class="form-control" ID="TxtApellidos" runat="server" sstyle="height:35px; width:80px; margin-left:15px"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtApellidos" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>
            <div class="form-group col">
              <label >Rut</label>
                <asp:TextBox type="Input" MaxLength="10" class="form-control" ID="TxtRut" runat="server" sstyle="height:35px; width:80px; margin-left:15px" placeholder="Ej:12641188-k"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtRut" Display="Dynamic"></asp:RequiredFieldValidator>
             </div>
        </div>
        <div class="form-row">
            <div class="form-group col-6">
              <label >Email</label>
                <asp:TextBox type="Input" class="form-control" ID="TxtEmail" runat="server" sstyle="height:35px; width:80px; margin-left:15px"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-4">
              <label >Dirección</label>
                <asp:TextBox type="Input" class="form-control" ID="TxtDireccion" runat="server" sstyle="height:35px; width:80px; margin-left:15px"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtDireccion" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-2">
              <label >N° casa</label>
                <asp:TextBox textmode="Number" class="form-control" ID="TxtNCasa" runat="server" sstyle="height:35px; width:80px; margin-left:15px" ControlToValidate="TxtNCasa"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtNCasa" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col">
              <label >Teléfono</label>
                <div class="input-group">
                  <div class="input-group-prepend">
                    <label class="input-group-text">+569</label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtTelefono" Display="Dynamic"></asp:RequiredFieldValidator>
                  </div>
                  <asp:TextBox class="form-control" MaxLength="8" ID="TxtTelefono" runat="server" sstyle="height:35px; width:80px; margin-left:15px" ValidateRequestMode="Enabled"></asp:TextBox>  
                </div>
                </div>
            <div class="form-group col">
              <label >Región</label>
                <asp:DropDownList ID="CmbRegion" class="form-control" runat="server" sstyle="height:35px; width:80px; margin-left:15px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="CargarCiudad"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="CmbRegion" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col">
              <label >Ciudad</label>
                <asp:DropDownList ID="CmbCiudad" class="form-control" runat="server" sstyle="height:35px; width:80px; margin-left:15px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="CargarComuna"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="CmbCiudad" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col">
              <label >Comuna</label>
                <asp:DropDownList ID="CmbComuna" class="form-control" runat="server" sstyle="height:35px; width:80px; margin-left:15px" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="CmbComuna" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col">
              <label >Servicio</label>
                <asp:DropDownList ID="CmbServicio" class="form-control" runat="server" sstyle="height:40px; width:80px; margin-left:15px" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="CmbServicio" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col">
              <label >Trabajador</label>
                <asp:DropDownList ID="CmbTrabajador" class="form-control" runat="server" sstyle="height:35px; width:80px; margin-left:15px" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="CmbTrabajador" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col">
              <label >Fecha a solicitar</label>
                <asp:TextBox ID="DtFecha" runat="server" textmode="DateTimeLocal" class="form-control"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="DtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col">
              <label >Requerimiento</label>
                <textarea id="TxtRequerimiento" class="form-control" cols="20" rows="2" runat="server"></textarea>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ErrorMessage="Este campo es requerido" ControlToValidate="TxtRequerimiento" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button Text="Enviar solicitud" ID="BtnEnviar" class="btn btn-primary" runat="server" OnClick="BtnEnviar_Click" />
    
    </div>

</asp:Content>
