   M S B A M L   `   `   `  ����A  =LMSWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LMSWPF.ViewsLMSWPF.Views  5          LMSWPF.Views.Publishers   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:LMSWPF.Views     5      -   5          N� Title$  
Publishers��5      $	��480��6   $	��930��6'   .��5
      � .+�5   
   � 
������� � ColumnDefinitions 5   
   �� 5      $
��361* �6   �� 5      $
��104* �6   .+�5   
   �� $��
Operations��6   $��16(�6'   $
��Left=�65   $	��454��6P   $��
716,19,0,7q�6]   $	��192��6q   $��2��6}   .��5      � 
�������.+�5      �� $��ID��6   $��30��6%   $��30��60    J� RenderTransformOrigin$ 
1.033,-1.3&�6<   $��7,45,143,351q�6_   �� 5      -   5         ��Name$ TxtId��5       �� TextWrapping$
 Wrap=�6)   $��48,51,48,349q�6=   ${�False��6S   �� 5      $��	Publisher��6   $��34��6,   $	��Top=�68   $��	5,78,94,0q�6P   �� 5      -   5        $ txtPublisher��5      $��28��60   $
 Wrap=�6<   $	��Top=�6P   $��	4,111,4,0q�6h   $ 0.941,0.633&�6{   �� 5      -   5         ��Name$ 	btnCreate��5      $��Create��6,   $��40,324,40,72q�6=   6S   �� 5      -   5        $ btnRead��5      $��Refresh��6*   $��40,359,40,37q�6<   6R   �� 5      -   5        $ 	btnUpdate��5      $��Update��6,   $��40,392,40,4q�6=   6R   5      5      �� 5   
   $��0��6   $��
Publishers��6#   $��16(�67   $
��Left=�6E   $	��459��6`   $��	11,10,0,0q�6m   $	��Top=�6�   $	��695��6�   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ dg��5   X      AlternatingRowBackground
 �����   RowBackground
 ����	   
IsReadOnly$
	 True��5   Q   
   AutoGenerateColumns$
 False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5      $
��Left=�6}   $	��420��6�   $��0,7,0,0q�6�   $	��Top=�6�   $	��680��6�      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!         
FontWeight$
 Bold"�6)   ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Id+  5"      $ 	Publisher��6)    6<   �� *Name+  5#      $ Status��6)    69   �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  5$         HeaderTemplate 5%      �� 5&      .R�5'   "   �� $��Action��6,   5(         CellTemplate 5*      �� 5+      .R�5,   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5-   &   �� $ 	btnDelete��6-   -   5        $��Delete��5-   @   6Q   5.   #   5/      51      53      54      55      56      57      