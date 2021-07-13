<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="VisualizarPunto.aspx.cs" Inherits="Servicio_web.Puntos_de_Carga.VisualizarPunto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-lg-6 col-md-4 col-sm-12">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h1>Tabla de puntos de Cargas</h1>
                </div>
                <div class="card-body">
                    <div>
                         <asp:DropDownList ID="Filtrord" runat="server" 
                    AutoPostBack="true" OnSelectedIndexChanged="Tipo_SelectedIndexChanged">
                    <asp:ListItem Value="0" Selected="True" Text="Todos"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Trafico"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Consumo"></asp:ListItem>


                </asp:DropDownList>
                    </div>
                    <div>
                         <asp:GridView ID="PuntoGrid" OnSelectedIndexChanged="PuntoGrid_SelectedIndexChanged"  CssClass="table" AutoGenerateColumns="false" runat="server">
                        <Columns>

                            <asp:BoundField DataField="Rut" HeaderText="Rut" ItemStyle-Width="150" />
                            <asp:BoundField DataField="Id" HeaderText="Id de Carga" ItemStyle-Width="150" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo de punto de carga" ItemStyle-Width="150" />
                            <asp:BoundField DataField="capacidadmaxima" HeaderText="Capacidad" ItemStyle-Width="150" />
                            <asp:BoundField DataField="fechavencimiento" HeaderText="Fecha de vencimiento" ItemStyle-Width="150" />
                           <asp:CommandField HeaderText="Seleccionar" SelectText="Editar" ControlStyle-CssClass="btn btn-warning text-black" ShowSelectButton="True" />
                            
                        </Columns>

                    </asp:GridView>
                    </div>
                   
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-4 col-sm-12">
            <div class="card">
                <div class="card-header bg-dark text-white ">
                    <h1>Edicion de Punto de cargar</h1>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label class="labels" for="Ruttxt">Rut de Estacion</label>
                        <asp:TextBox ReadOnly="true" ID="Ruttxt" CssClass="inputs" runat="server" />

                    </div>
                    <br />
                    <div class="form-group">
                        <label class="labels">Id de punto de carga</label>
                        <asp:TextBox ReadOnly="true" CssClass="inputs" runat="server" ID="IDnumCarga" />
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="labels">Tipos</label>
                        <asp:RadioButtonList RepeatLayout="flow" RepeatDirection="Vertical" ID="TiposRd" CssClass=" Radios" Width="40%" runat="server">
                            <asp:ListItem Value="1" Selected="True" Text="Trafico" />
                            <asp:ListItem Value="2" Text="Consumo" />
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="labels">Capacidad Maxima</label>
                        <asp:TextBox ID="Capacidadtxt" CssClass="inputs" runat="server" />
                    </div>
                    <br />
                    <div class="form-group">
                        <label class=" labels">fecha de Vencimiento</label>
                        <asp:TextBox ID="Fechatxt" CssClass="inputs" runat="server" />
                        <asp:CustomValidator runat="server" ID="FechaCV" ErrorMessage="CustomValidator"
                            CssClass="text-danger" ControlToValidate="Fechatxt" ValidateEmptyText="true" OnServerValidate="FechaCV_ServerValidate"></asp:CustomValidator>
                    </div>
                    <br />
                </div> 
                <div class="card-footer">
                    <div><asp:Button ID="EditarBtn" CssClass=" btn btn-info text-white " OnClick="EditarBtn_Click" Text="Editar punto de carga" runat="server" /></div>
                    <div>
                        <asp:GridView ID="ErroresGrid"   AutoGenerateColumns="false" CssClass="table text-danger" runat="server">
                            <Columns>
                                 <asp:BoundField DataField="Errores" HeaderText="Errores" ItemStyle-Width="150" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
