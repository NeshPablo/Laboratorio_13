<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="Laboratorio_13.Actualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="font-size: xx-large">
        Actualizar</p>
    <p style="font-size: small">
        Carne:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: small">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar Alumno" />
    </p>
    <p style="font-size: small">
        Nombre:&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: small">
        Apellido&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: small">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Editar Alumno" />
    </p>
</asp:Content>
