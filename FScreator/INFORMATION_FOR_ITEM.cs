﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FScreator
{
    public partial class INFORMATION_FOR_ITEM : Form
    {
        public INFORMATION_FOR_ITEM()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void INFORMATION_FOR_ITEM_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = @"
Вид
Тип иконки - icon-type и сама иконка - icon
В последней версии движка существуют следующие типы иконок предметов, определяющих то, как предмет будет отображаться в инвентаре:

none - невидимый тип, используется только для core:empty (пустой предмет). Не влияет на появление предмета на панель доступа к контенту. Тип может быть удалён в будущем
sprite - 2D изображение. Требуется указание свойства icon, состоящее из имени атласа и имени текстуры в этом атласе, разделённые :. Пример: blocks:notfound. На данный момент в движке существует два текстурных атласа:
blocks (генерируется из png файлов в res/textures/blocks/)
items (генерируется из png файлов в res/textures/items/)
block - отображает предпросмотр блока. В icon указывается строковый id блока который нужно отображать. Пример base:wood
Поведение
Устанавливаемый блок - placing-block
При указании строкового id блока предмет устанавливает его при нажатии ПКМ. Именно это свойство используется у всех сгенерированных для блоков предметов.

Пример: предмет ставит блоки базальта:

""placing-block"": ""base:bazalt""
Излучение - emission
Влияет на свет излучаемый предметом, когда он находится в руке игрока.

Массив из трех целых чисел - R, G, B освещения от 0 до 15.

Примеры:

[15, 15, 15] - самый яркий белый свет
[7, 0, 0] - слабый красный свет
[0, 0, 0] - предмет не излучает свет (по-умолчанию)
Свойства добавленные в разрабатываемой версии 0.18
Размер стопки (стека) - stack-size
Определяет максимальное количество предмета в одном слоте. Значение по-умолчанию - 64.";
        }
    }
}
