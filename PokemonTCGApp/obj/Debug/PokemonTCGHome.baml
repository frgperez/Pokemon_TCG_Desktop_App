   M S B A M L   `   `   `  ����H  DPokemonTCGApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PokemonTCGAppPokemonTCGApp  5      "    PokemonTCGApp.PokemonTCGHome   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PokemonTCGApp     5        N� Title$  PokemonTCG - Home��5	      .��5      � $��
10,10,0,10q�6    � 	Resources 5   
      pkmnCardSetsSource � XPath  nameItemTemplate �� XPath
 � Tag��%�  &	        &	 �    � 5      $ PKMNSets��69   .��5      ��<PKMNSets xmlns="">
                        <Sets Name="Generations">
                            <Folder>Generations</Folder>
                        </Sets>
                        <Sets Name="XY - Promo">
                            <Folder>XYPromo</Folder>
                        </Sets>
                    </PKMNSets>        5      �� 5      .R�5      �� ��6   �� $ @Name�� 68   �� $ @Folder��6X   5      5       � ColumnDefinitions 5   
   �� 5        � RowDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      �� 5%      $
��Auto �6   .+�5(   
   �� $��0��6   $��0��6!   $��35��6.    �� Padding$ 5q�6:   ���#4E87D4$��0,0,10,0q�6[   ._�5)      �� -   5        $
��Test��5)      $��Center=�6    
�������$��0,0,10,0q�6N   .��6`   	Card Sets6k   5*      �� 5+   
   -   5        $��
setListBox��5+       �� SelectedValuePath$ Folder��6$   $��0��6?   $��1��6O   $��0,0,10,0q�6\   #��[ 5-      ��5,      �� 	 �� Source#	 [  $
 Sets��5.      �� 50   
   -   5        $��0��50      $��2��6!   $��	0,10,10,0q�6.   $	��125��6A   $��25��6M   $��Right=�6Y   .��6�   View6�   51      52      