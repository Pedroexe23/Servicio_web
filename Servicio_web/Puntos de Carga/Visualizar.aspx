<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Visualizar.aspx.cs" Inherits="Servicio_web.Puntos_de_Carga.Visualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
                    <asp:GridView ID="EstacionGrid" CssClass="table" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                runat="server" AutoGenerateColumns="false" OnRowCommand="EstacionGrid_RowCommand">
                    <Columns>
                    <asp:BoundField DataField="Rut" HeaderText="Rut" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Horario Inicio" HeaderText="Horario Inicio" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Horario Cierre" HeaderText="Horario Cierre" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Direcion" HeaderText="Direcion" ItemStyle-Width="150" />
                    <asp:BoundField DataField="Region" HeaderText="Region" ItemStyle-Width="150" />
                    <asp:TemplateField HeaderText="Accion" ItemStyle-Width="80" >
                        <ItemTemplate >
                            <asp:Button  runat="server" CommandName="Eliminar" ID="EliminarBtn" Text="Eliminar Estacion"  CssClass="btn btn-danger text-white"  CommandArgument='<%# Eval("Rut") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
              
         
            </asp:GridView>

        
    </div>
</asp:Content>
