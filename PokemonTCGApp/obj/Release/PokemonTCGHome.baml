   M S B A M L   `   `   `  ���� H  DPokemonTCGApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PokemonTCGAppPokemonTCGApp  "    PokemonTCGApp.PokemonTCGHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:PokemonTCGApp       N� Title$  PokemonTCG - Home��.��� $��
10,10,0,10q� � 	Resources    pkmnCardSetsSource � XPath  nameItemTemplate �� XPath
 � Tag��%�  &	        &	 h    � $ PKMNSets��.����<PKMNSets xmlns="">
                        <Sets Name="Generations">
                            <Folder>Generations</Folder>
                        </Sets>
                        <Sets Name="XY - Promo">
                            <Folder>XYPromo</Folder>
                        </Sets>
                    </PKMNSets>        �� .R��� ���� $ @Name�� �� $ @Folder�� � ColumnDefinitions ��  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+��� $��0��$��0��$��35�� �� Padding$ 5q����#4E87D4$��0,0,10,0q�._��� -   $
��Test��$��Center=�
�������$��0,0,10,0q�.��	Card Sets�� -   $��
setListBox�� �� SelectedValuePath$ Folder��$��0��$��1��$��0,0,10,0q�#��[ ���� 	 �� Source#	 [  $
 Sets���� -   $��0��$��2��$��	0,10,10,0q�$	��125��$��25��$��Right=�.��View