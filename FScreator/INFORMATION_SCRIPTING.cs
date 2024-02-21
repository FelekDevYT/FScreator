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
    public partial class INFORMATION_SCRIPTING : Form
    {
        public INFORMATION_SCRIPTING()
        {
            InitializeComponent();
        }

        private void INFORMATION_SCRIPTING_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = @"
В качестве языка сценариев используется LuaJIT

На данном этапе, скриптинг реализован в тестовом режиме и будет активно развиваться, с изменением (иногда и радикальным) API движка.

Функции, доступные в скриптах
load_script(""контентпак:scripts/имя_скрипта.lua"") -- загружает скрипт, если ещё не загружен
load_script(""контентпак:scripts/имя_скрипта.lua"", true) -- перезагружает скрипт
require ""контентпак:имя_модуля"" -- загружает lua модуль из папки modules (расширение не указывается)
block_name(id) 
Возвращает строковый id блока, принимая в качестве агрумента числовой

block_index(id)
Возвращает числовой id блока, принимая в качестве агрумента строковый

get_block(x, y, z)
Возвращает числовой id блока на указанных координатах

get_block_states(x, y, z)
Возвращает состояние (поворот + доп. информация) в виде целого числа

set_block(x, y, z, id, states)
Устанавливает блок с заданным числовым id и состоянием (0 - по-умолчанию) на заданных координатах. НЕ вызывает событие on_placed

is_solid_at(x, y, z)
Проверяет, является ли блок на указанных координатах полным

is_replaceable_at(x, y, z)
Проверяет, можно ли на заданных координатах поставить блок (примеры: воздух, трава, цветы, вода)

blocks_count()
Возвращает количество id доступных в движке блоков

Следующие три функции используется для учёта вращения блока при обращении к соседним блокам или других целей, где направление блока имеет решающее значение.

get_block_X(x, y, z)
Возвращает целочисленный единичный вектор X блока на указанных координатах с учётом его вращения (три целых числа). Если поворот отсутствует, возвращает 1, 0, 0

get_block_Y(x, y, z)
Возвращает целочисленный единичный вектор Y блока на указанных координатах с учётом его вращения (три целых числа). Если поворот отсутствует, возвращает 0, 1, 0

get_block_Z(x, y, z)
Возвращает целочисленный единичный вектор Z блока на указанных координатах с учётом его вращения (три целых числа). Если поворот отсутствует, возвращает 0, 0, 1

Пользовательские биты
Выделенная под использования в скриптах часть поля voxel.states хранящего доп-информацию о вокселе, такую как вращение блока. На данный момент выделенная часть составляет 8 бит.

get_block_user_bits(x, y, z, offset, bits)
Возвращает выбранное число бит с указанного смещения в виде целого беззнакового числа

set_block_user_bits(x, y, z, offset, bits, value)
Записывает указанное число бит значения value в user bits по выбранному смещению

Библиотека player
player.get_pos(id)
Возвращает x, y, z координаты игрока

player.set_pos(id, x, y, z)
Устанавливает x, y, z координаты игрока

player.get_rot(id) -> number, number
Возвращает x, y вращения камеры (в радианах), где значение X не ограничено

player.set_rot(id, x, y, z) 
Устанавливает x, y вращения камеры (в радианах)

player.get_inventory(playerid) -> integer, integer
Возвращает id инвентаря игрока и индекс выбранного слота (от 0 до 9)

Библиотека world
world.get_day_time() -> number
Возвращает текущее игровое время от 0.0 до 1.0, где 0.0 и 1.0 - полночь, 0.5 - полдень.

world.set_day_time(time)
Устанавливает указанное игровое время.

world.get_total_time()
Возвращает общее суммарное время, прошедшее в мире

world.get_seed()
Возвращает зерно мира.

Библиотека gui
Библиотека содержит функции для доступа к свойствам UI элементов. Вместо gui следует использовать объектную обертку, предоставляющую доступ к свойствам через мета-методы __index, __newindex:

local inventory_doc = Document.new(""id-макета"")
print(inventory_doc.some_button.text)
indentory_doc.some_button.text = ""new text""
В скрипте макета layouts/файл_макета.xml - layouts/файл_макета.xml.lua уже доступна переменная document содержащая объект класса Document

Библиотека inventory
Библиотека функций для работы с инвентарем.

inventory.get(invid: integer, slot: integer) -> integer, integer
Принимает id инвентаря и индекс слота. Возвращает id предмета и его количество. id = 0 (core:empty) обозначает, что слот пуст.

inventory.set(invid: integer, slot: integer, itemid: integer, count: integer)
Устанавливает содержимое слота.

inventory.size(invid: integer) -> integer
Возращает размер инвентаря (число слотов). Если указанного инвентаря не существует, бросает исключение.

inventory.add(invid: integer, itemid: integer, count: integer) -> integer
Добавляет предмет в инвентарь. Если не удалось вместить все количество, возвращает остаток.

inventory.get_block(x: integer, y: integer, z: integer) -> integer
Функция возвращает id инвентаря указанного блока. Если блок не может иметь инвентарь - возвращает 0.

inventory.bind_block(invid: integer, x: integer, y: integer, z: integer)
Привязывает указанный инвентарь к блоку.

inventory.unbind_block(x: integer, y: integer, z: integer)
Отвязывает инвентарь от блока.

Warning

Инвентари, не привязанные ни к одному из блоков, удаляются при выходе из мира.

inventory.clone(invid: integer) -> integer
Создает копию инвентаря и возвращает id копии. Если копируемого инвентаря не существует, возвращает 0.

Библиотека item
item.name(itemid: integer) -> string
Возвращает строковый id предмета по его числовому id (как block_name)

item.index(name: string) -> integer
Возвращает числовой id предмета по строковому id (как block_index)

item.stack_size(itemid: integer) -> integer
Возвращает максимальный размер стопки для предмета.

item.defs_count() -> integer
Возвращает общее число доступных предметов (включая сгенерированные)

Библиотека hud
hud.open_inventory()
Открывает инвентарь

hud.close_inventory()
Возвращает id инвентаря блока (при inventory-size=0 создаётся виртуальный инвентарь, который удаляется после закрытия), и id макета UI.

Закрывает инвентарь

hud.open_block(x, y, z) -> integer, string
Note

Одновременно может быть открыт только один блок

Открывает инвентарь и UI блока. Если блок не имеет макета UI - бросается исключение.

hud.open_permanent(layoutid: string)
Добавляет постоянный элемент на экран. Элемент не удаляется при закрытии инвентаря. Чтобы не перекрывать затенение в режиме инвентаря нужно установить z-index элемента меньшим чем -1. В случае тега inventory, произойдет привязка слотов к инвентарю игрока.

hud.close(layoutid: string)
Удаляет элемент с экрана

События блоков
function on_placed(x, y, z, playerid)
Вызывается после установки блока игроком

function on_broken(x, y, z, playerid)
Вызывается после разрушения блока игроком

function on_interact(x, y, z, playerid)
Вызывается при нажатии на блок ПКМ. Разрешает установку блоков, если возвращает true

function on_update(x, y, z)
Вызывается при обновлении блока (если изменился соседний блок)

function on_random_update(x, y, z)
Вызывается в случайные моменты времени (рост травы на блоках земли)

function on_blocks_tick(tps)
Вызывается tps (20) раз в секунду

События предметов
function on_use_on_block(x, y, z, playerid)
Вызывается при нажатии ПКМ на блок. Предотвращает установку блока, прописанного в placing-block если возвращает true

function on_block_break_by(x, y, z, playerid)
Вызывается при нажатии ЛКМ на блок (в т.ч неразрушимый). Предотвращает разрушение блока, если возвращает true

События мира
События мира для контент-пака прописываются в scripts/world.lua

function on_world_open()
Вызывается при загрузке мира

function on_world_save()
Вызывается перед сохранением мира

function on_world_quit()
Вызывается при выходе из мира (после сохранения)

События макета
События прописываются в файле layouts/имя_макета.xml.lua.

function on_open(invid, x, y, z)
Вызывается при добавлении элемента на экран. При отсутствии привязки к инвентарю invid будет равен 0. При отсутствии привязки к блоку x, y, z так же будут равны 0.

function on_close(invid)
Вызывается при удалении элемента с экрана.

События HUD
События связанные с игровым интерфейсом прописываются в файле scripts/hud.lua

function on_hud_open(playerid)
Вызывается после входа в мир, когда становится доступна библиотека hud. Здесь на экран добавляются постоянные элементы.

function on_hud_close(playerid)
Вызывается при выходе из мира, перед его сохранением.

Библиотеки движка
file
Библиотека функций для работы с файлами

file.resolve(путь: string) -> string
Функция приводит запись точка_входа:путь (например user:worlds/house1) к обычному пути. (например C://Users/user/.voxeng/worlds/house1)

Note

Функцию не нужно использовать в сочетании с другими функциями из библиотеки, так как они делают это автоматически

Возвращаемый путь не является каноническим и может быть как абсолютным, так и относительным.

file.read(путь: string) -> string
Читает весь текстовый файл и возвращает в виде строки

file.write(путь: string, текст: string) -> nil
Записывает текст в файл (с перезаписью)

file.length(путь: string) -> integer
Возвращает размер файла в байтах, либо -1, если файл не найден

file.exists(путь: string) -> boolean
Проверяет, существует ли по данному пути файл или директория

file.isfile(путь: string) -> boolean
Проверяет, существует ли по данному пути файл

file.isdir(путь: string) -> boolean
Проверяет, существует ли по данному пути директория

file.mkdir(путь: string) -> boolean
Создаёт директорию. Возвращает true если была создана новая директория

time
time.uptime() -> number
Возвращает время с момента запуска движка в секундах";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}