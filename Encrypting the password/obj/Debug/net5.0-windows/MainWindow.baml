   M S B A M L   `   `   `  ����R  NEncrypting the password, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Encrypting_the_passwordEncrypting_the_password  5   	   (    "Encrypting_the_password.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Encrypting_the_password     5   	     � Title$  
Encrypting��5	   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65   .��5
      � ��5   
   �� 5       �� ImageSource$ /Resources/image.jpg��6   6>   .+�5   
   �� -   5         ��Name$ tbLogin��5      $��Center=�6#   $	��Top=�6@   $	��200��6X   $��30��6d   $	��180q�6p   �� 5   
   
�������$��Login��6#   $��Center=�63   $��0,180,280,0q�6P   $	��Top=�6e   $��33��6}   $��61��6�   �� 5   
   
�������$��Password��6#   $��Center=�66   $��0,250,280,0q�6S   $	��Top=�6h    J� RenderTransformOrigin$ 
0.218,0.48&�6�   $��33��6�   $��61��6�   �� 5   
   -   5        $ 
tbPassword��5      $��Center=�6&   $	��Top=�6C   $	��200��6[   $��30��6g   $��	0,250,0,0q�6s   �� 5   
   
�������$��
Login page��6#   $��Center=�68   $��	0,100,0,0q�6U   $	��Top=�6h   $��24(�6�   �� 5   
   -   5         ��Name$ Login��5      $��Login��6    $��Center=�60   $��0,300,110,0q�6M   $	��Top=�6b   $ -1.58,0.371&�6z   $��88��6�   $��25��6�   $��15(�6�   
�����_���5      �� *DataContext.LoginCommand+ �� RelativeSource ��  �� AncestorType
 Window��6s   ��  � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 5��65   5      5      5      �� 5   
   -   5        $ Register��5      $��Register��6#   $��Center=�66   $��110,300,0,0q�6S   $	��Top=�6h   $ -1.58,0.371&�6�   $��88��6�   $��25��6�   $��15(�6�   
�����_���5      �� *DataContext.RegisterCommand+ �� 
 Window��6v   ��  5      ��%^   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 5��65   5       5!      5"      �� 5#   
   -   5         ��Name$ 
loginLabel��5#      $
��Left=�6$   $��514,181,0,0q�6?   $	��Top=�6T   $��30��6l   $ 0.5,0.5&�6x   $	��100��6�   $y�Hidden=�6�   z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$ 1.298Q�6&   T� 5)      5*      5,      �� 5-   
   -   5        $ registerLabel��5-      $
��Left=�6'   $��514,251,0,0q�6B   $	��Top=�6W   $��30��6o   $ 0.5,0.5&�6{   $	��100��6�   $y�Hidden=�6�   z�5.      V� 5/      .~�50      �� �� 51      �� 52      $ 1.298Q�6&   T� 53      54      56      57      58      