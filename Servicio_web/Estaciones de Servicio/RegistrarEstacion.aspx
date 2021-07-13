<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="RegistrarEstacion.aspx.cs" Inherits="Servicio_web.Estaciones_de_Servicio.RegistrarEstacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-5">
        <div class="col-12 col-md-6 col-lg-6 mx-auto ">

            <asp:Label ID="RegistroLabel" CssClass="text-success h1" Text="" runat="server" />
            <div class="card">
                <div class="card-header">
                    <h1>Registrar estacion </h1>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label class="labels" for="rutxt">Rut</label>
                        <asp:TextBox runat="server" ID="rutxt" CssClass="inputs"> </asp:TextBox>
                        <asp:CustomValidator ID="rutCV" runat="server" ErrorMessage="CustomValidator"
                            CssClass="text-danger" ControlToValidate="rutxt"
                            OnServerValidate="rutCV_ServerValidate" ValidateEmptyText="true"></asp:CustomValidator>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="labels" for="direcciontxt">Direccion </label>
                        <asp:TextBox runat="server" ID="direcciontxt" CssClass="inputs"> </asp:TextBox>


                    </div>
                    <br />
                    <div class="form-group">
                        <label class="labels" for="regiontxt">Region</label>
                        <asp:DropDownList ID="RegionTxt" runat="server">
                            <asp:ListItem Value="15" Text="Arica y Parinacota" />
                            <asp:ListItem Value="1" Text="Tarapaca" />
                            <asp:ListItem Value="2" Text="Antofagasta" />
                            <asp:ListItem Value="3" Text="Atacama" />
                            <asp:ListItem Value="4" Text="Coquimbo" />
                            <asp:ListItem Value="5" Text="Valparaíso" />
                            <asp:ListItem Value="13" Text="Metropolitana de Santiago" />
                            <asp:ListItem Value="6" Text="Libertador General Bernardo O’Higgins" />
                            <asp:ListItem Value="7" Text="Maule" />
                            <asp:ListItem Value="8" Text="Biobío" />
                            <asp:ListItem Value="9" Text="La Araucanía" />
                            <asp:ListItem Value="10" Text="Los Lagos" />
                            <asp:ListItem Value="11" Text="Aysén del General Carlos Ibáñez del Campo" />
                            <asp:ListItem Value="12" Text="Magallanes y la Antártica Chilena" />
                            <asp:ListItem Value="14" Text="Los Ríos" />
                            <asp:ListItem Value="16" Text="Ñuble" />
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="labels" for="HoraITxt">Hora de Inicio: </label>
                        <asp:TextBox runat="server" ID="HoraITxt" CssClass="inputs"></asp:TextBox>
                        <asp:CustomValidator ID="HICV" OnServerValidate="HICV_ServerValidate" ErrorMessage="CustomValidator" CssClass="text-danger" ControlToValidate="HoraITxt" ValidateEmptyText="true" runat="server"></asp:CustomValidator>
                        <label class="labels2" for="HoraFTxt">Hora de Cierre: </label>
                        <asp:TextBox runat="server" ID="HoraFTxt" CssClass="inputs"></asp:TextBox>
                        <asp:CustomValidator ID="HCCV" OnServerValidate="HCCV_ServerValidate" ErrorMessage="CustomValidator" CssClass="text-danger" ControlToValidate="HoraFTxt" ValidateEmptyText="true" runat="server"></asp:CustomValidator>

                    </div>
                <br />
                <div class="form-group">

                    <label class="labels" for="capacidadTxt">Capacidad: </label>
                    <asp:TextBox runat="server" ID="capacidadTxt" CssClass="inputs"></asp:TextBox>

                </div>
                </div>
                <div class="card-footer">
                    <asp:Button ID="ingresarBtn" runat="server" Text="Crear Estacion"
                        CssClass="btn btn-dark text-white"
                        OnClick="ingresarBtn_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="ErroresGrid" CssClass="text-danger" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
