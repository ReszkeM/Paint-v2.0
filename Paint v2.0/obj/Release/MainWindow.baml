   M S B A M L   `   `   `  ����   
Paint v2.0    Paint_v2._0.Paint   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  -     � Title$  Untitled - Paint��   BlankWindow#��[  $	��860��$	��640�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$	 New��  -   $
 Open��  -   $
 Save��  -   $
 Undo��  -   $
 Redo�� J� InputBindings �� 
 �� Key$ N�� �� 	Modifiers$ Controlf� �� Command$	 New���� $ O��$ Controlf�$
 Open���� $ S��$ Controlf�$
 Save���� $ Z��$ Controlf�$
 Undo���� $ Y��$ Controlf�$
 Redo��.��]� ���	#FFAEA3A3.+�o� $	��Top=�$��25��$��1,1,1,0q����	#FFDEE7EC.@�m� $��_File��$��40��$��25�� m� StaysOpenOnClick . $��14(����	#FFDEE7EC.@�m� -   $
��_New��#��� ��#��� �� m� InputGestureText$ ctrl+N���� m� -   $��_Open��#��� ��#��� ��$ ctrl+O��m� -	   $��_Save��#��� ��#��� ��$ ctrl+S���� m� -
   $��_Exit��#��� ��#��� ��$ alt+f4��m� $��_Edit��$��40��$��25�� . $��14(����	#FFDEE7EC.@�m� -   $��_Undo��#��� ��#��� ��$ ctrl+z��m� -   $��_Redo��#��� ��#��� ��$ ctrl+y��m� $��_View��$��45��$��25�� . $��14(����	#FFDEE7EC.@�m� -   $��_Vertical flip��#��� ��#��� ��m� -   $��_Horizontal flip��#��� ��#��� ���� m� -   $!��_Rotate 90 degrees to right��#��� ��#��� ��m� -   $ ��_Rotate 90 degrees to left��#��� ��#��� ��m� -   $��_Rotate 180 degrees��#��� ��#��� ��]� $	��Top=�$��1,0,1,1q�$��80�����	#FFDEE7EC	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   
BlurRadius$
 15Q�   Color# � ��   	Direction$ 90Q�   ShadowDepth$ 3Q�   Opacity$	 0.8Q�.+��� -   $��
ColorWheel��$��60��$��60��$��5,5,0,2q�$	��Top=�$
��Left=�$$��Resources/ColorWhell_60x60.jpg��$
��Fill=� � ToolTip _� .���� .+��� $
��Bold"�Color wheel�� Click to pick color.�� -   $��drawingColorBox��$��40��$��40��$��5,5,0,2q����	#FF000000$	��Top=�$
��Left=� _� .���� .+��� $
��Bold"�Color�� Drawing color.�� $��Color��$��18��$
��auto��$��
-36,45,0,5q�$	��Top=�$
��Left=��� $��Colors��$��18��$
��auto��$��	-65,0,0,0q�$��Bottom=�$
��Left=�$��10(��� ���	#FF92A3A6$��Center=�$
��Left=�$	��5,0q�$��1��$��70���� -   $��PencilButton��$��30��$��30��$	��Top=�$
��Left=�$��0,20,0,5q�$��2q�.���� $��Resources/Pencil.png�� _� .���� .+��� $
��Bold"�Pencil�� Click to draw with pencil.�� -   $��EraserButton��$��30��$��30��$	��Top=�$
��Left=�$��2,20,0,5q�$��2q�.���� $��Resources/Eraser.png�� _� .���� .+��� $
��Bold"�Eraser�� Click to use eraser.�� -   $��
FillButton��$��30��$��30��$	��Top=�$
��Left=�$��2,20,0,5q�$��2q�.���� $��Resources/Fill.jpg�� _� .���� .+��� $
��Bold"�Fill��  Click to fill area with color.�� -   $��ColorPickerButton��$��30��$��30��$	��Top=�$
��Left=�$��2,20,0,5q�$��2q�.���� $��Resources/ColorPicker.png�� _� .���� .+��� $
��Bold"�ColorPicker��  Click to get color from pixel.�� $��Items��$��18��$
��auto��$��	-75,0,0,0q�$��Bottom=�$
��Left=�$��10(��� ���	#FF92A3A6$��Center=�$
��Left=�$	��5,0q�$��1��$��70���� -   $��RectangleButton��$��30��$��30��$	��Top=�$
��Left=�$��0,20,0,5q�$��2q�.���� $��Resources/Rectangle.png�� _� .���� .+��� $
��Bold"�	Rectangle�� Click to draw an rectangle.�� -   $��EllipseButton��$��30��$��30��$	��Top=�$
��Left=�$��2,20,0,5q�$��2q�.���� $��Resources/Ellipse.jpg�� _� .���� .+��� $
��Bold"�	Ellipse�� Click to draw an ellipse.�� -   $��
LineButton��$��30��$��30��$	��Top=�$
��Left=�$��2,20,0,5q�$��2q�.���� $��Resources/Line.png�� _� .���� .+��� $
��Bold"�Line�� Click to draw an line.�� $��Shapes��$��18��$
��auto��$��	-63,0,0,0q�$��Bottom=�$
��Left=�$��10(��� ���	#FF92A3A6$��Center=�$
��Left=�$	��5,0q�$��1��$��70��]� -   $��MyDockPanel��$��1,0,1,1q����	#FFC6D3DA.+��� $��Bottom=�$��Bottom=�$��25��$
��auto�����	#FFD3DADE.@��� -   $��Position��$	��100��$��25��$
��Left=�$��Center=�$��Center=�$�� ���� -   $��
CanvasSize��$	��100��$��25��$
��Left=�$��Center=�$��Center=�$��450 x 350px���� $	��Top=�$
��auto��$
��auto��$��5,5,0,0q�$
��Auto=�$
��Auto=�$
��Left=�$	��Top=�	   $
 15Q�# � ��   RenderingBias$ Quality=�.���� -   $��PaintSurface��$	��Top=�$
��Left=�$	��350��$	��450�����	#FFFFFFFF$��0q�� -   $��myGrid��$
��left=�$	��top=�$��	455,0,0,0q�.+��� -    $��CanvasResizeButton��
���   �$��5��$��5�� � Cursor$ SizeNWSE���� $��Bottom=�$��Bottom=�$
��Left=����	#FFAEA3A3$
��auto��$��1��