   M S B A M L   `   `   `  ����C  ?ListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ListViewListView  5   	       ListView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ListView     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��525��6)   .��5	      �� .+�5
   
   �� -   5         ��Name$ li��5
      $	��Top=�6   $	��150��67   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��75��6=   $��30��6H   ��6!   �� *	Content+6V   �� 5       �� TextAlignment$ Center=�6:   $	��100��6Q   $��20��6]   ��6$   �� *Text+6k   5      5      5      �� 5   
   -   5        $	 li1��5      $	��Top=�6    $	��150��68    �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$	 150��63    �� DisplayMemberBinding 6?   �� *Name+6g   �� 5      $	��Age��6%   $ 75��62    6=   �� *Age+6d   �� 5      $��Email��6%   $	 120��64    6@   �� *Email+6i   �� 5      $��Province��6%   $	 120��67    6C   �� *
Province+6o   5      5      �� 5   
   -   5        $	 li2��5      $	��Top=�6    $	��150��68    5      �� 5       .P�5!      �� $
��Name��6%   $	 150��63    6?   �� *Name+6g   �� 5"      $	��Age��6%   $ 75��62    6=   �� *Age+6d   �� 5#      $��Email��6%   $	 120��64    6@   �� *Email+6i   �� 5$      $��Province��6%   $	 120��67    6C   �� *
Province+6o   5%       �� 
GroupStyle 50      (  "System.Windows.Controls.GroupStyle  51         ContainerStyle 52      �� 53      	 �� 
TargetType"	 ��6    .�54      �� 
 �� Property
 � �� �� Value 55   "   �� 56   &   .R�57   *   9�  9� 
IsExpanded .  9� ExpandDirection$
 Down=�6E   ��58   .   �� 59   2   $ 
Horizontal=�6=   .+�5:   6   �� $
��Bold"�6V   $��14(�6h   $
��Left=�6v   ��6@   �� *Name+6�   �� 5;   6   $��14(�6[   
��� E��$��	10,0,10,0q�6�   $��Center=�6�   ��6@   �� *	ItemCount+6�   �� 5<   6   $��items��6@   $��14(�6M   
����ح�$��Italic$�6r   $��Right=�6�   6�   5=   3   .��5?   .   �� 5@   +   5A   '   5C      5D      5F      5H      5I      5J      