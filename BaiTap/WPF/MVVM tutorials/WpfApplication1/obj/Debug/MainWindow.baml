   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   D @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel 5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   ;self*clr-namespace:ViewModel;assembly=ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)    � DataContext 5
      !  ViewModel.SinhVienViewModel  5   
   6#   .��5      �� .+�5   
   �� -   5         ��Name$ 
livStudent��5       �� SelectionMode$ Single=�5      ��. $	��150��6O   ��5   '   �� *ListSinhVien+ �� View 5      �� 5      .P�5      �� $��ID��6%    �� CellTemplate 5      �� 5      .R�5   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5   &   �� $��X��6-   6;   �� 5   &   $�� ��60   6;   �� 5   &   ��60   �� *Id+6F   5   #   5      5      �� 5      $
��Tên��6%    5      �� 5      .R�5    "   � .+�5!   &   �� ��60   �� *Ten+6G   5"   #   5#      5%      5&      5(      �� 5*   
   -   5         ��Name$ 
stpStudent��5*      $��0 10 0 0q�6)   .+�5+      �� $��ID��6   6$   �� 5,      -   5         ��Name$ txbId��5,      ��6'   �� 	 �� ElementName$	 
livStudent��
 �� Path$
 SelectedItem.Id� �� Mode$ OneWay=�6t   �� 5.      $
��Tên��6   6%   �� 5/      -   5        $ txbTen��5/      ��6&   �� $	 
livStudent��$
 SelectedItem.Ten�$ OneWay=�6s   50      �� 52   
   $ 
Horizontal=�6   $��0 10 0 0q�6.   .+�53      �� $��Thêm��6   $��50��6$   ��6/   �� *
AddCommand+��6N   �� $	 
stpStudent��$
 Children�6�   �� 54      $
��Xóa��6   $
��10 0q�6�   $��50��6�   ��6#   �� *DeleteCommand+��6E   �� $
 SelectedItem�$	 
livStudent��6�   55      56      57      