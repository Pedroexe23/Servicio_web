<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="RegistrarPunto.aspx.cs" Inherits="Servicio_web.Puntos_de_Carga.RegistrarPunto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Registrotxt" CssClass="text-success h1 " runat="server" />
    <div class="card">
        <div class="card-header">
            <h1>Registrar Punto de Carga</h1>
        </div>
        <div class="card-body">
            <div class="row mt-5">
                <div class="col-12 col-md-6 col-lg-6">
                    <div class="card">
                        <div class="card-header bg-info text-white">
                            <h1>Ingresar Punto de Carga</h1>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label class="labels" for="Ruttxt">Rut de Estacionamiento</label>
                                <asp:TextBox ID="Ruttxt" CssClass="inputs" runat="server" />
                                <asp:CustomValidator ID="rutCV" runat="server" ErrorMessage="CustomValidator"
                                    CssClass="text-danger" ControlToValidate="RutTxt"
                                    OnServerValidate="rutCV_ServerValidate" ValidateEmptyText="true"></asp:CustomValidator>
                            </div>
                            <br />
                            <div class="form-group">
                                <label class="labels">id De punto de carga</label>
                                <asp:TextBox CssClass="inputs" runat="server" ID="numCarga" />
                            </div>

                            <br />
                            <div class="form-group">
                                <label class="labels">Tipos</label>
                                <asp:RadioButtonList TextAlign="Right" RepeatLayout="flow" RepeatDirection="Horizontal" ID="TiposRd" CssClass=" Radios" Width="40%" runat="server">
                                    <asp:ListItem Value="1" Selected="True" Text="Trafico" />
                                    <asp:ListItem Value="2" Text="Consumo" />
                                </asp:RadioButtonList>

                            </div>
                            <br />
                            <div class="form-group">
                                <label class="labels">Capacidad Maxima</label>
                                <asp:TextBox ID="Capacidad" CssClass="inputs" runat="server" />
                            </div>
                            <br />
                            <div class="form-group">
                                <label class=" labels">fecha de vencimiento</label>
                                <asp:TextBox ID="Fechatxt" CssClass="inputs" runat="server" />
                                <asp:CustomValidator runat="server" ID="FechaCV" ErrorMessage="CustomValidator"
                                    CssClass="text-danger" ControlToValidate="Fechatxt" ValidateEmptyText="true" OnServerValidate="FechaCV_ServerValidate"></asp:CustomValidator>
                            </div>
                            <br />
                        </div>
                        <div class="card-footer">
                            <div>
                                <asp:Button ID="Registrarbtn" CssClass="btn btn-success text-white " OnClick="Registrarbtn_Click" Text="Registrar Punto de carga" runat="server" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
        <asp:GridView ID="ErroresGrid" CssClass="text-danger h3" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
