   M S B A M L   `   `   `  ����  Bierbank%    Bierbank.View.BierNoteToevoegen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  BierNoteToevoegen��5	       � DataContext 5      ��    ViewModelLocator �� Source# [   �� Path$ BierNoteToevoegenModel� � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value �� Self �� RelativeSource��%�   '��       �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      �� 	 �@�ToolTip
 60   �� # Z $2 ,(Validation.Errors).CurrentItem.ErrorContent�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5!   
   �� $��0��6   $��0��6   $��15(�6-   $��
Onderwerp:��6;   �� 5"   
   $��0��6   $��1��6   $��20q�6/   $��15(�6;   ��6I   �� *BierNote.Onderwerp+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� 5$   
   $��1��6   $��0��6   $��15(�6-   $��Note:��6;   �� 5%   
   $��1��6   $��1��6   $��15(�6/   $��20q�6=    �� TextWrapping$
 Wrap=�6I   ��6]   �� *BierNote.Beschrijving+$ TwoWay=� . �� 5'   
   $��2��6   $��0��6   $��15(�6-   $��Bier:��6;   �� 5(   
   $��2��6   $��1��6    $��20q�60    �� DisplayMemberPath$
 Naam��5*       �� SelectedValuePath$ Id��5+       �� SelectedIndex$ 0��5-      ��5)      �� *
Biertjes+ �� SelectedValue 5,      �� *BierNote.BierId+$ TwoWay=�5-      �� 5/   
   -   5        $��KnopToevoegen��5/   :   $��3��6   $��1��6   $��20q�6.   $��Note toevoegen��6O     ToolBarButton#���  6h   ��6�   �� *InsertCommand+50      51      