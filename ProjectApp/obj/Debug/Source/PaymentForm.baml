   M S B A M L   `   `   `  ����  
ProjectApp#    ProjectApp.Source.PaymentForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  PaymentForm��5   	   $	��500��6   $	��800��6*    � WindowStyle$
 None=�66   ���	#FFF18B10$��4q�6a    � WindowStartupLocation$ CenterScreen=�6u    � 
ResizeMode$ NoResize=�6�    � Topmost . ���	#FF8D4C1F.��5      �  � RowDefinitions 5   
   �� 5      $��92 �6   �� 5      $��4* �6   �� 5	      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridReceiptInfo��5      $��100,20,100,21q�6,      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6C      CanUserResizeColumns .  	   CanUserResizeRows	 .  
   AutoGenerateColumns
 .     CanUserAddRows .  $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Product��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$ Product�   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$ Center=�6D   �� 5       � ��$ Center=�6B   �� 5       � ��$ 16(�69   �� 5       � ��$ SemiBold"�6;   5         HeaderStyle 5      �� 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5      ��  � ��$ Center=�6K   �� 5       � ��$ 20(�69   �� 5       � ��$
 Bold"�6;   5      5        5      $ Amount��6%    65   �� $ Amount� 5      �� 5       " ��6    .�5!      ��  � ��$ Center=�6D   �� 5"       � ��$ Center=�6B   �� 5#       � ��$ 16(�69   �� 5$       � ��$ SemiBold"�6;   5%       5'      �� 5(      "  6    .�5)      ��  � ��$ Center=�6K   �� 5*       � ��$ 20(�69   �� 5+       � ��$
 Bold"�6;   5,      5.        5/      $ Price��6%    64   �� $ Price� 50      �� 51      " ��6    .�52      ��  � ��$ Center=�6D   �� 53       � ��$ Center=�6B   �� 54       � ��$ 16(�69   �� 55       � ��$ SemiBold"�6;   56       58      �� 59      "  6    .�5:      ��  � ��$ Center=�6K   �� 5;       � ��$ 20(�69   �� 5<       � ��$
 Bold"�6;   5=      5?      5A      �� 5B   
   $<��6ขอบคุณที่ใช้บริการ��6   $��227,15,227,28q�6-   
�������$��Center=�6W   $��Center=�6{   $��29(�6�   $��	ExtraBold"�6�   �� 5C   
   -   5         ��Name$ lbTotalPrice��5C      $�� ��6&   
�������$��20(�6D   $��
0,10,100,0q�6R   $��2��6f   $��Right=�6s   $	��220��6�   $��49��6�   $	��Top=�6�   $��Right=�6�   $��Center=�6�   �� 5D   
   $p��j*หน้าจอจะปิดอัตโนมัติหลังจากชำระเงิน��6   
�������$��18(�6R   $��
0,10,404,0q�6`   $��2��6t   $��Right=�6�   $	��288��6�   $��49��6�   $	��Top=�6�   $
��Left=�6�   $��Center=�6�   5E      5F      