   M S B A M L   `   `   `  ����J  FValue Converter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Value_ConverterValue_Converter  5   	        Value_Converter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3	converterclr-namespace:Value_Converter     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5	      +   %Value_Converter.YesNoBooleanConverter 	  yesNo��%   &	          5
   
   6:   5      .��5      �� .+�5   
   �� -   5        $��txbValue��5      6$   � 5   
   .+�5      �� $��Current value is: ��6   64   �� 5      ��6   ��  �� ElementName$ txbValue�� �� Path$
 Text� �� 	Converter# [  6m   5      �� 5   
    d� 	IsChecked 6   �� $ txbValue��$
 Text�# [  .��6j   Yes6o   5      5      