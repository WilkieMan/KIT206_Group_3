   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KIT206_RAP
KIT206_RAP  5   	       KIT206_RAP.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:KIT206_RAP     5   	     � Title$#  Researcher Assessment Program��5   	   $
��Auto��6/   $
��Auto��6=   .��5	      � $��0, 0, 4, -1q�6   
������� � ColumnDefinitions 5
   
   �� 5      $
��235* �6   �� 5      $
��754* �6   .+�5   
   ]� $��0��6   
�������$��0,0,0.333,-0.667q�6;   .+�5      �� -   5         ��Name$ 
FilterView��5   F    �� Orientation$ Vertical=�6   $��0,0,0,-0.667q�60   .+�5      �� $"��Reseacher Assessment Program��6   $��15(�6@   
�������6N   �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ DetailsViewButton��5      $��View Details��68   $��	30,10,0,0q�6O   6b   �� 5      -   5        $ ReportsViewButton��5      $��View Reports��68   $��0��6O   $
��Left=�6_   $��	30,10,0,0q�6z   $	��Top=�6�   $��75��6�   6�   5      �� 5      .+�5      �� $��Search by name...��6    $��10(�69   
�������$��
10,10,10,0q�6_   $��80��6s   $
��Left=�6~   �� 5      -   5         ��Name$ FilterByNameBox��5      $��
10,1,10,10q�67   6K   5      �� 5      -   5         ��Name$ FilterByTitleBox��5      $��10,10,10,10q�65   6J   �� 5      .+�5      �� -   5         ��Name$ ResearcherListView��5      $	��600��6;   $��10,10,10,10q�6H   $	��Top=�6]   $	��220��6u   6�   5      5      5      �� 5!   
   $��1��6   $��0.667,0,0.333,-0.667q�6=   ��6)   �� 6=   5"      5#      