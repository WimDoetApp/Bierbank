   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       Bierbank   Bierbank.View.BierDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        N� Title$  
BierDetail��5
       � DataContext 5      ��    ViewModelLocator �� Source# [   �� Path$ BierDetailModel� � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value �� Self �� RelativeSource��%�   '��       �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      �� 	 �@�ToolTip
 60   �� # Z $2 ,(Validation.Errors).CurrentItem.ErrorContent�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5    
   �� 5!      $	��600 �6   �� 5"      .+�5%   
   �� $��0��6   $��15(�6   $��Naam:��6+   �� 5&   
   $��0��6   $��15(�6   $	��300��6-   $��20q�69   ��6E   �� *SelectedBiertje.Naam+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� 5(   
   $��1��6   $��15(�6   $��Soort:��6+   �� 5)   
   $��1��6   $��15(�6   $	��300��6-    �� TextWrapping$
 Wrap=�69   $��20q�6M   ��6Y   �� *SelectedBiertje.Soort+$ TwoWay=��� 5+   
   $��2��6   $��15(�6   $��Percentage:��6+    � ToolTip 5,      _� 5-      .��5.      �� .+�5/      �� CAIngeven als komma getal, gescheiden door een punt. Bv: 5% is 0.056g   50      51      53      �� 54   
   $��2��6   $��15(�6   $	��300��6-   $��20q�69   ��6E   �� *SelectedBiertje.Percentage+$ TwoWay=� . �� 56   
   $��3��6   $��15(�6   $��
Brouwerij:��6+   �� 57   
   $��3��6   $��15(�6   $	��300��6-   $��20q�69   ��6E   �� *SelectedBiertje.Brouwerij+$ TwoWay=��� 59   
   $��4��6   $��15(�6   $��Image:��6+   �� 5:   
   $��4��6   $	��300��6   $��Image veranderen��6*   $��5q�6E     ToolBarButton#���  6P   ��6x   �� *ImageUploadCommand+�� 5<   
   $��5��6   $��0��6   $	��Top=�6-   $��15(�6E   $��Notes bij dit bier:��6S   �� 5=   
   -   5        $��ListViewNotes��5=   M   $��5��6   $��2��6    $��25q�61   $��0��6=   ��6b   �� *	BierNotes+ �� SelectedItem 6�   �� *SelectedBierNote+��5>      �� 5?      .R�5@      �� $��10(�6   ��6*   �� *	Onderwerp+5A      .   (System.Windows.Interactivity.Interaction   Triggers 5D      /   )System.Windows.Interactivity.EventTrigger  5E         	EventName$ MouseDoubleClick��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 5F      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *WeergevenCommand+5G      5I      �� 5K   
   -   5        $��	ImageName��5K      $y�	Collapsed=�6%   ��5L      `� 5M       �� StringFormat$ {0}{1}��6   .1�5N      �� $
 Root�6   �� 5O      $ SelectedBiertje.Image�6   5P      5R      �� 5T   
   -   5        $��KnopWijzigen��5T   ?   $��2��6   $��0��6"   $��1��6/   $��Wijzigen��6S   $��35q�6f   #���  6r   ��6�   �� *WijzigenCommand+�� 5V   
   -   5        $��KnopVerwijderen��5V   ?   $��2��6   $��2��6"   $��1��6/   $��Verwijderen��6V   $��35q�6l   #���  6x   ��6�   �� *DeleteCommand+�� 5X   
   $��4��6   $��3��6   $��1��6.   ��6>   �� *Text+ �� ElementName$ 	ImageName��5Y      5Z      