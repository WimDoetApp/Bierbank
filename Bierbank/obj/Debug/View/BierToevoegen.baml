   M S B A M L   `   `   `  ����  Bierbank!    Bierbank.View.BierToevoegen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  BierToevoegen��5	       � DataContext 5      ��    ViewModelLocator �� Source# [   �� Path$ BierToevoegenModel� � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value �� Self �� RelativeSource��%�   '��       �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      �� 	 �@�ToolTip
 60   �� # Z $2 ,(Validation.Errors).CurrentItem.ErrorContent�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       .+�5#   
   �� $��0��6   $��0��6   $��15(�6-   $��Naam:��6;   �� 5$   
   -   5        $��textBoxNaam��5$   =   $��0��6   $��1��6   $��15(�6/   $��20q�6P   ��6\   �� *SelectedBiertje.Naam+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� 5&   
   $��1��6   $��0��6   $��15(�6-   $��Soort:��6;   �� 5'   
   -   5        $��textBoxSoort��5'   =   $��1��6   $��1��6   $��15(�6/   $��20q�6Q   ��6]   �� *SelectedBiertje.Soort+$ TwoWay=��� 5)   
   $��2��6   $��0��6   $��15(�6-   $��Percentage:��6;    � ToolTip 5*      _� 5+      .��5,      �� .+�5-      �� CAIngeven als komma getal, gescheiden door een punt. Bv: 5% is 0.056g   5.      5/      51      �� 52   
   -   5        $��textBoxPercentage��52   =   $��2��6   $��1��6   $��15(�6/   $��20q�6V   ��6b   �� *SelectedBiertje.Percentage+$ TwoWay=� . �� 54   
   $��3��6   $��0��6   $��15(�6-   $��
Brouwerij:��6;   �� 55   
   -   5        $��textBoxBrouwerij��55   =   $��3��6   $��1��6   $��15(�6/   $��20q�6U   ��6a   �� *SelectedBiertje.Brouwerij+$ TwoWay=��� 57   
   $��4��6   $��0��6   $��15(�6-   $��Image:��6;   �� 58   
   $��4��6   $��1��6   $��Image toevoegen��6.   $��20q�6H     ToolBarButton#���  6T   ��6|   �� *ImageUploadCommand+�� 5:   
   -   5        $��KnopToevoegen��5:   .   $��5��6   $��1��6   $��Bier toevoegen��6C   $��20q�6\   #���  6h   ��6�   �� *InsertCommand+5;      5<      