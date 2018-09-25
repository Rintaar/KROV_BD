-- phpMyAdmin SQL Dump
-- version 4.4.15.5
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 06 2018 г., 15:29
-- Версия сервера: 5.5.48
-- Версия PHP: 5.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `roofingDB`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Crew`
--

CREATE TABLE IF NOT EXISTS `Crew` (
  `id` int(11) NOT NULL,
  `name` varchar(155) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Crew`
--

INSERT INTO `Crew` (`id`, `name`) VALUES
(11, 'team_R');

-- --------------------------------------------------------

--
-- Структура таблицы `JobKind`
--

CREATE TABLE IF NOT EXISTS `JobKind` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL COMMENT 'название работы',
  `addition` int(11) NOT NULL COMMENT 'дополнения '
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Таблица выполняемых работ.';

--
-- Дамп данных таблицы `JobKind`
--

INSERT INTO `JobKind` (`id`, `name`, `addition`) VALUES
(1, 'Земляные работы', 0),
(2, 'Горновскрышные работы', 0),
(3, 'Буровзрывные работы', 0),
(4, 'Скважины', 0),
(5, 'Свайные работы. Опускные колодцы. Закрепление грунтов', 0),
(6, 'Бетонные и железобетонные конструкции монолитные', 0),
(7, 'Бетонные и железобетонные конструкции сборные', 0),
(8, 'Конструкции из кирпича и блоков', 0),
(9, 'Металлические конструкции', 0),
(10, 'Деревянные конструкции', 0),
(11, 'Полы', 0),
(12, 'Кровли', 0),
(13, 'Защита строительных конструкций и оборудования от коррозии', 0),
(14, 'Конструкции в сельском строительстве', 0),
(15, 'Отделочные работы', 0),
(16, 'Трубопроводы внутренние', 0),
(17, 'Водопровод и канализация - внутренние устройства', 0),
(18, 'Отопление - внутренние устройства', 0),
(19, 'Газоснабжение - внутренние устройства', 0),
(20, 'Вентиляция и кондиционирование воздуха', 0),
(21, 'Временные сборно-разборные здания и сооружения', 0),
(22, 'Водопровод - наружные сети', 0),
(23, 'Канализация - наружные сети', 0),
(24, 'Теплоснабжение и газопроводы - наружные сети', 0),
(25, 'Магистральные и промысловые трубопроводы', 0),
(26, 'Теплоизоляционные работы', 0),
(27, 'Автомобильные дороги', 0),
(28, 'Железные дороги', 0),
(29, 'Тоннели и метрополитены', 0),
(30, 'Мосты и трубы', 0),
(31, 'Аэродромы', 0),
(32, 'Трамвайные пути', 0),
(33, 'Линии электропередачи', 0),
(34, 'Сооружения связи, радиовещания и телевидения 2', 0),
(35, 'Горнопроходческие работы', 0),
(36, 'Земляные конструкции гидротехнических сооружений', 0),
(37, 'Бетонные и железобетонные конструкции гидротехнических сооружений', 0),
(38, 'Каменные конструкции гидротехнических сооружений', 0),
(39, 'Металлические конструкции гидротехнических сооружений', 0),
(40, 'Деревянные конструкции гидротехнических сооружений', 0),
(41, 'Гидроизоляционные работы в гидротехнических сооружениях', 0),
(42, 'Берегоукрепительные работы', 0),
(43, 'Судовозные пути стапелей и слипов', 0),
(44, 'Подводно-строительные (водолазные) работы', 0),
(45, 'Промышленные печи и трубы', 0),
(46, 'Работы при реконструкции зданий и сооружений', 0),
(47, 'Озеленение, защитные лесонасаждения', 0),
(51, 'Земляные работы', 0),
(52, 'Фундаменты', 0),
(53, 'Стены', 0),
(54, 'Перекрытия', 0),
(55, 'Перегородки', 0),
(56, 'Проёмы', 0),
(57, 'Полы', 0),
(58, 'Кровли', 0),
(59, 'Лестницы, крыльца', 0),
(60, 'Печные работы', 0),
(61, 'Штукатурные работы', 0),
(62, 'Малярные работы', 0),
(63, 'Стекольные, обойные и облицовочные работы', 0),
(64, 'Лепные работы', 0),
(65, 'Внутренние санитарно-технические работы', 0),
(66, 'Наружные инженерные сети', 0),
(67, 'Электромонтажные работы', 0),
(68, 'Благоустройство', 0),
(69, 'Прочие ремонтно-строительные работы', 0),
(101, 'Материалы для общестроительных работ', 0),
(102, 'Лесоматериалы', 0),
(103, 'Трубы стальные, чугунные, асбестоцементные, полимерные и керамические', 0),
(104, 'Материалы для теплоизоляционных работ', 0),
(105, 'Материалы верхнего строения пути железных дорог широкой колеи', 0),
(106, 'Материалы верхнего строения пути железных дорог узкой колеи', 0),
(107, 'Материалы верхнего строения трамвайных путей', 0),
(108, 'Материалы для метрополитенов и тоннелей', 0),
(109, 'Материалы для горнопроходческих работ', 0),
(110, 'Материалы для сооружений связи', 0),
(111, 'Материалы и изделия для сигнализаций, централизации, автоблокировки и электрификации железных дорог', 0),
(112, 'Материалы для взрывных общестроительных и горнопроходческих работ', 0),
(113, 'Материалы для антикоррозионных и защитных покрытий', 0),
(114, 'Материалы для удобрения и химических средств защиты растений', 0),
(115, 'Огнеупорные материалы и изделия', 0),
(116, 'Малые архитектурные формы', 0),
(117, 'Материалы для ремонтно-реставрационных работ', 0),
(201, 'Стальные конструкции промышленных и сельскохозяйственных зданий, сооружений и мостов', 0),
(202, 'Стальные конструкции гидротехнических сооружений', 0),
(203, 'Деревянные конструкции и изделия. Блоки и сборочные элементы оконные, балконные и дверные', 0),
(204, 'Арматура товарная для железобетонных конструкций', 0),
(205, 'Литые конструкции промышленных печей и труб', 0),
(206, 'Алюминиевые конструкции', 0),
(301, 'Санитарно-технические материалы и изделия', 0),
(302, 'Трубопроводы, арматура, фасонные и соединительные части', 0),
(401, 'Бетоны', 0),
(402, 'Растворы строительные', 0),
(403, 'Бетонные и железобетонные изделия', 0),
(404, 'Кирпич, камни, черепица', 0),
(405, 'Известь и гипсовые вяжущие', 0),
(406, 'Заполнители керамзитовые, шунгизитовые, аглопоритовые и другие', 0),
(407, 'Земля, глина, торф, грунт, грунтовые смеси', 0),
(408, 'Щебень, гравий, песок и смеси из природных материалов', 0),
(409, 'Щебень, песок, шлак и смеси из металлургических шлаков', 0),
(410, 'Продукция асфальтобетонная и асфальтобитумная', 0),
(411, 'Вода, пар, сжатый воздух, электроэнергия', 0),
(412, 'Изделия облицовочные из природного камня', 0),
(413, 'Камни бортовые, мостовые и стеновые из природного камня', 0),
(414, 'Материалы для озеленения', 0),
(415, 'Гипсовые и цементные изделия', 0),
(445, 'Бетонные и железобетонные изделия для специального строительства', 0),
(501, 'Кабели', 0),
(502, 'Провода, шнуры, проволока, шины и муфты кабельные', 0),
(503, 'Линейно-кабельные изделия связи', 0),
(504, 'Электроконструкции', 0),
(506, 'Прокатно-тянутые изделия из цветных металлов и цветные металлы', 0),
(507, 'Трубы, арматура и детали трубопроводов', 0),
(508, 'Канаты стальные', 0),
(509, 'Прочие материалы\r\n', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Manager`
--

CREATE TABLE IF NOT EXISTS `Manager` (
  `id` int(11) NOT NULL COMMENT 'id',
  `FIO` varchar(255) NOT NULL COMMENT 'ФИО',
  `login` varchar(255) NOT NULL COMMENT 'логин',
  `password` varchar(255) NOT NULL COMMENT 'пароль',
  `bill` double NOT NULL COMMENT 'счет(остаток)',
  `Em_login` varchar(255) NOT NULL COMMENT 'логин от почты',
  `Em_password` varchar(255) NOT NULL COMMENT 'пароль от почты',
  `Em_Server` varchar(255) NOT NULL COMMENT 'где почтовый сервер',
  `Project_list` text NOT NULL COMMENT 'список проектов'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `Matherials`
--

CREATE TABLE IF NOT EXISTS `Matherials` (
  `id` int(11) NOT NULL,
  `code` varchar(20) NOT NULL COMMENT 'код объекта',
  `name` varchar(255) NOT NULL COMMENT 'наименование',
  `mat_measure` varchar(20) NOT NULL COMMENT 'единица измерения материалов',
  `mat_price` float NOT NULL COMMENT 'стоимость единицы материала',
  `measure` varchar(20) NOT NULL COMMENT 'единица измерения наименования',
  `mat_for_one` int(11) NOT NULL COMMENT 'количество материалов на единицу наименования',
  `full_price` float NOT NULL COMMENT 'полная стоимость за единицу наименования',
  `work_price` double NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=1628 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Matherials`
--

INSERT INTO `Matherials` (`id`, `code`, `name`, `mat_measure`, `mat_price`, `measure`, `mat_for_one`, `full_price`, `work_price`) VALUES
(1545, '15-02-016-03', 'Штукатурка стен (улучшенная)', '100 м2', 20, '30 кг/шт', 280, 5600, 0),
(1546, '15-04-027-05', 'Окраска и шпатлевание стен ', '100 м2', 10, '25 кг/шт', 316, 3160, 0),
(1547, '63-05-01', 'Снятие обоев ', '100 м2', 0, '', 0, 0, 0),
(1548, '15-06-001-01', 'Оклейка стен обоями (снятие обоев не оплачивается)', '100 м2', 10, '10 м2', 500, 5000, 0),
(1549, '15-07-003-03', 'Грунтование водно-дисперсионной грунтовкой "Нортекс-Грунт" поверхностей: ', '100 м2', 3, '10 кг', 224, 672, 0),
(1550, '46-04-010-1   ', 'Демонтаж напольных покрытий(с плинтусами) асфальтовых и асфальтобетонных', '100 м2', 0, 'м2', 0, 0, 0),
(1551, '46-04-010-2  ', 'Демонтаж напольных покрытий(с плинтусами) дощатых', '100 м2', 123, 'м2', 0, 0, 0),
(1552, '46-04-010-3   ', 'Демонтаж напольных покрытий(с плинтусами) паркетных', '100 м2', 0, 'м2', 0, 0, 0),
(1553, '57-03-01 ', 'Демонтаж плинтусов: деревянных и из пластмассовых материалов', '100 м', 0, 'мп', 0, 0, 0),
(1554, '46-04-009-1  ', 'Цементно-песчаная стяжка (с разборкой)  на гравии', '100 м2', 2, 'м2', 2300, 4600, 0),
(1555, '46-04-009-2   ', 'Цементно-песчаная стяжка (с разборкой) на кирпичном щебне', '100 м2', 2, 'м2', 2300, 4600, 0),
(1556, '11-01-011-01', 'Цементно-песчаная стяжка (с разборкой)', '100 м2', 2, 'м2', 2300, 4600, 0),
(1557, '11-01-011-02 ', 'на каждые послед 5 мм', '100 м2', 2, 'м2', 2300, 5750, 0),
(1558, '11-01-053-01', 'Устройство оснований полов из фанеры в один слой площадью: до 20 м2', '100 м2', 100, 'м2', 320, 32000, 0),
(1559, '11-01-053-02', 'Устройство оснований полов из фанеры в один слой площадью: свыше  20м2', '100 м2', 100, 'м2', 320, 32000, 0),
(1560, '11-01-053-03', 'Устройство оснований полов из фанеры в два слоя площадью:', '100 м2', 200, 'м2', 320, 64000, 0),
(1561, '11-01-053-04', 'Устройство оснований полов из фанеры в два слоя площадью:', '100 м2', 200, 'м2', 320, 64000, 0),
(1562, '11-01-036-01 ', 'на клее бустилат', '100 м2', 100, '40 м2', 365, 36500, 0),
(1563, '11-01-036-03', 'на сухо', '100 м2', 100, '40 м2', 365, 36500, 0),
(1564, '11-01-036-04 ', 'на сварке', '100 м2', 100, '40 м2', 365, 36500, 0),
(1565, '11-01-040-01 ', 'Монтаж плинтуса (пол)     пвх', '100 м', 40, 'шт', 42, 1680, 0),
(1566, '11-01-039-01 ', 'Монтаж плинтуса (пол)   деревянные', '100 м', 100, 'мп', 140, 14000, 0),
(1567, '11-01-039-04 ', 'Монтаж плинтуса (пол)   керамические', '100 м', 34, 'м2', 35, 1190, 0),
(1568, '15-01-047-15', 'Монтаж потолка типа ARMSTRONG', '100 м2', 100, 'м2', 320, 32000, 0),
(1569, '61-04-11/15-02-036-0', 'Штукатурка потолка ', '100 м2', 20, '25 кг/шт', 280, 5600, 0),
(1570, '15-04-007-02', 'Окраска и шпатлевка потолка ', '100 м2', 10, '30 кг/шт', 316, 3160, 0),
(1571, '46-04-012-03 ', 'Демонтаж + монтаж двери однопольной(с доводчиком)', '100м2', 0, 'м2', 0, 0, 0),
(1572, '10-01-047-01 ', 'монтаж двери однопольной(с доводчиком)', '100м2', 0, 'м2', 0, 0, 0),
(1573, '57-02-03', 'Демонтаж керамической плитки', '100 м2', 0, 'м2', 0, 0, 0),
(1574, '11-01-027-02', 'Укладка плитки ', '100 м2', 100, 'м2', 310, 31000, 0),
(1575, '11-01-027-03', 'Укладка бордюра из керамической плитки', '100 м2', 34, 'м2', 35, 1190, 0),
(1576, '65-19-01/18-03-001-0', 'Демонтаж + монтаж радиатора отопления', '100кВТ', 10, 'шт', 350, 3500, 0),
(1577, '66-01-02', 'Демонтаж труб х/г воды или канализации чугунные', '100 м', 0, 'мп', 0, 0, 0),
(1578, '17-01-005-04', 'Установка раковины', '10 компл', 10, 'компл', 1000, 10000, 0),
(1579, '46-03-012-02', 'Штробление стен под трубы', '100 м', 0, 'мп', 0, 0, 0),
(1580, '12-01-105-01', 'Установка труб из металлопластика, меди', '100 м', 100, 'мп', 70, 7000, 0),
(1581, '12-01-106-01', 'Установка труб из металлопластика, меди', '100 м', 100, 'мп', 70, 7000, 0),
(1582, '17-01-003-01', 'Установка унитаза ', '10 компл', 10, 'компл', 2000, 20000, 0),
(1583, '16-04-004-01', 'Прокладка канализации', '100 м', 100, 'мп', 170, 17000, 0),
(1584, '16-04-002-02', 'Прокладка труб водоснабжения', '100 м', 100, 'мп', 49, 4900, 0),
(1585, '67-04-05', 'Демонтаж светильника', '100 шт', 0, 'шт', 0, 0, 0),
(1586, '08-03-526-01', 'Установка автомата электрического', 'шт', 1, 'шт', 165, 165, 0),
(1587, '08-10-010-01', 'Прокладка гофры открыто', '100 м', 100, 'мп', 18, 1800, 0),
(1588, '08-03-574-01', 'Подключение кабеля электрического', '100 жил', 100, 'мп', 43, 4300, 0),
(1589, '08-03-575-01', 'Монтаж щита электрического ', 'шт', 1, 'шт', 460, 460, 0),
(1590, '67-04-1', 'Замена выключателя, розетки', '100 шт', 0, 'шт', 0, 0, 0),
(1591, '08-03-591-09', 'розетка', '100 шт', 100, 'шт', 70, 7000, 0),
(1592, '08-03-591-02', 'выключатель', '100 шт', 100, 'шт', 60, 6000, 0),
(1593, '46-04-008-01', 'Разборка  покрытий кровель из рулонных материалов', '100 м2', 0, '', 0, 0, 0),
(1594, '12-01-016-02', 'Огрунтовка оснований праймером', '100м2', 1, 'шт', 1000, 1000, 0),
(1595, '12-01-002-10', 'Устройство кровельного покрытия в 1 слой', '100 м2', 110, 'м2', 136, 14960, 0),
(1596, '12-01-002-09', 'Устройство кровельного покрытия в 2 слоя', '100 м2', 110, 'м2', 258, 28380, 0),
(1597, '12-01-004-04', 'Устройство примыканий до 600м без фартуков', '100 м ', 60, 'м2', 136, 8160, 0),
(1598, '12-01-004-05', 'Устройство примыканий свыше 600м', '100 м ', 60, 'м2', 258, 15480, 0),
(1599, '12-01-013-03', 'Утепеление покрытия минватой/пенопластом полистирольным', '100 м2', 5, 'м3', 2500, 12500, 0),
(1600, '12-01-013-01', 'Утепеление покрытия минватой/пенопластом полистирольным', '100 м2', 5, 'м3', 2500, 12500, 0),
(1601, '12-01-017-01', 'Устройство стяжки 15мм', '100 м2', 1, 'м3', 2300, 3450, 0),
(1602, '12-01-017-05', 'Устройство стяжки из сборных асбестоцементных листов в 1 слой', '100м2', 34, 'шт', 613, 20842, 0),
(1603, '58-20-02', 'Смена обделок из листовой стали ', '100 м', 0, '', 0, 0, 0),
(1604, '58-16-03', 'Ремонт стяжки местами площадью заделки до 1,0 м2', '100 мест', 1, 'м3', 2300, 3450, 0),
(1605, '58-07-06', 'Смена существующего рулонного ковра на покрытия из наплавляемых материалов: в два слоя', '100 м2', 110, 'м2', 258, 28380, 0),
(1606, '26-01-036-01', 'Утепление минвата/пенопласт', '100 м2', 5, 'м3', 2500, 12500, 0),
(1607, '15-01-090-03', 'Монтаж керамогранита с утеплителем', '100 м2', 110, 'м2', 450, 49500, 0),
(1608, '15-01-090-04', 'Монтаж керамогранита без утеплителя', '100 м2', 110, 'м2', 450, 49500, 0),
(1609, '15-01-065-01', 'Монтаж маталлосайдинга с утеплителем ', '100 м2', 110, 'м2', 390, 42900, 0),
(1610, '53-15-1', 'Ремонт наружных кирпичных стен', '100 м2', 25, 'м3', 10, 78000, 0),
(1611, '15-02-036-01', 'Штукатурка по сетке без каркаса', '100 м2', 20, '25 кг/шт', 245, 4900, 0),
(1612, '53-14-1', 'Заделка трещин в стенах цементным раствором', '10 м', 0, '', 0, 0, 0),
(1613, '62-25-7', 'Шпатлевка ранее окрашенных фасадов', '100 м2', 10, '20 кг/шт', 450, 4500, 0),
(1614, '15-04-019-08', 'Окраска фасадов', '100 м2', 2, '14 кг/шт', 490, 1225, 0),
(1615, '62-39-1', 'Промывка поверхности, окрашенной масляными красками стен и фасадов', '100 м2 промытой пове', 1, '1', 1, 1, 1),
(1616, '61-2-7', 'Ремонт штукатурки внутренних стен по камню и бетону цементно-известковым раствором, площадью отдельных мест до 1 м2 толщиной слоя до 20 мм', '100 м2 отремонтирова', 1, '1', 1, 1, 1),
(1617, '15-04-007-01', 'Окраска водно-дисперсионными акриловыми составами улучшенная по штукатурке стен', '100 м2 окрашиваемой ', 1, '1', 1, 1, 1),
(1618, '101-3171', 'Шпатлевка Ветонит LR, расход   1,18 кг на 1м2', 'т', 1, '1', 1, 1, 1),
(1619, '63-7-5', 'Разборка облицовки стен из керамических глазурованных плиток', '100 м2 поверхности о', 1, '1', 1, 1, 1),
(1620, '46-02-009-02', 'Отбивка штукатурки с поверхностей стен и потолков кирпичных', '100 м2', 1, '1', 1, 1, 1),
(1621, '15-02-019-03', 'Сплошное выравнивание внутренних поверхностей (однослойное оштукатуривание)из сухих растворных смесей толщиной до 10 мм стен', '100 м2 оштукатуривае', 1, '1', 1, 1, 1),
(1622, '101-2430', 'Грунтовка <Тифенгрунд>, КНАУФ', 'кг', 1, '1', 1, 1, 1),
(1623, '15-01-019-05', 'Гладкая облицовка стен, столбов, пилястр и откосов (без карнизных, плинтусных и угловых плиток) без установки плиток туалетного гарнитура на клее из сухих смесей по кирпичу и бетону', '100 м2 поверхности о', 1, '1', 1, 1, 1),
(1624, '62-39-1', 'Промывка поверхности, окрашенной масляными красками стен и фасадов', '100 м2 промытой пове', 1, '1', 1, 1, 1),
(1625, '61-2-7', 'Ремонт штукатурки внутренних стен по камню и бетону цементно-известковым раствором, площадью отдельных мест до 1 м2 толщиной слоя до 20 мм', '100 м2 отремонтирова', 1, '1', 1, 1, 1),
(1626, '15-04-025-08', 'Улучшенная окраска масляными составами по штукатурке стен', '100 м2 окрашиваемой ', 1, '1', 1, 1, 1),
(1627, '62-11-5', 'Улучшенная масляная окраска ранее окрашенных полов за два раза с расчисткой старой краски до 35%', '100 м2 окрашиваемой ', 1, '1', 1, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Object`
--

CREATE TABLE IF NOT EXISTS `Object` (
  `id` int(11) NOT NULL COMMENT 'стандартный id',
  `name` varchar(255) NOT NULL COMMENT 'название объекта',
  `address` varchar(255) NOT NULL COMMENT 'адрес объекта',
  `jobkind` text NOT NULL,
  `date_auction` date NOT NULL COMMENT 'дата аукциона',
  `date_contract` date NOT NULL COMMENT 'дата договора',
  `date_plan` date NOT NULL COMMENT 'дата теоритического выполнения',
  `date_real` date NOT NULL COMMENT 'дата фактического выполнения',
  `date_payment` date NOT NULL COMMENT 'дата оплаты',
  `crew` int(11) NOT NULL COMMENT 'бригада на работу',
  `Photo` varchar(255) DEFAULT NULL COMMENT 'Фото объекта',
  `status` tinyint(1) NOT NULL COMMENT 'статус объекта'
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8 COMMENT='Основная таблица объекта';

--
-- Дамп данных таблицы `Object`
--

INSERT INTO `Object` (`id`, `name`, `address`, `jobkind`, `date_auction`, `date_contract`, `date_plan`, `date_real`, `date_payment`, `crew`, `Photo`, `status`) VALUES
(19, 'name', 'address', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" />\r\n</DataSet>', '2018-02-22', '2018-02-22', '2018-02-22', '2018-02-22', '2018-02-22', 16, NULL, 1),
(34, 'Проект 234', 'СПБ улица там там там', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1" msdata:CaseSensitive="False" msdata:Locale="ru-RU">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Code" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Fullprice" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Workprice" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">\r\n    <table>\r\n      <Table1 diffgr:id="Table11" msdata:rowOrder="0" diffgr:hasChanges="inserted">\r\n        <Code>62-39-1</Code>\r\n        <Name>Промывка поверхности, окрашенной масляными красками стен и фасадов</Name>\r\n        <Count>3.06</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>3.06</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table12" msdata:rowOrder="1" diffgr:hasChanges="inserted">\r\n        <Code>61-2-7</Code>\r\n        <Name>Ремонт штукатурки внутренних стен по камню и бетону цементно-известковым раствором, площадью отдельных мест до 1 м2 толщиной слоя до 20 мм</Name>\r\n        <Count>3.06</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>3.06</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table13" msdata:rowOrder="2" diffgr:hasChanges="inserted">\r\n        <Code>15-04-007-01</Code>\r\n        <Name>Окраска водно-дисперсионными акриловыми составами улучшенная по штукатурке стен</Name>\r\n        <Count>3.06</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>3.06</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table14" msdata:rowOrder="3" diffgr:hasChanges="inserted">\r\n        <Code>101-3171</Code>\r\n        <Name>Шпатлевка Ветонит LR, расход   1,18 кг на 1м2</Name>\r\n        <Count>0.3611</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>0.3611</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table15" msdata:rowOrder="4" diffgr:hasChanges="inserted">\r\n        <Code>63-7-5</Code>\r\n        <Name>Разборка облицовки стен из керамических глазурованных плиток</Name>\r\n        <Count>1.44</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>1.44</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table16" msdata:rowOrder="5" diffgr:hasChanges="inserted">\r\n        <Code>46-02-009-02</Code>\r\n        <Name>Отбивка штукатурки с поверхностей стен и потолков кирпичных</Name>\r\n        <Count>1.44</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>1.44</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table17" msdata:rowOrder="6" diffgr:hasChanges="inserted">\r\n        <Code>15-02-016-03</Code>\r\n        <Name>Штукатурка стен (улучшенная)</Name>\r\n        <Count>1.44</Count>\r\n        <Price>5600</Price>\r\n        <Fullprice>8064</Fullprice>\r\n        <Workprice>0</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table18" msdata:rowOrder="7" diffgr:hasChanges="inserted">\r\n        <Code>15-02-019-03</Code>\r\n        <Name>Сплошное выравнивание внутренних поверхностей (однослойное оштукатуривание)из сухих растворных смесей толщиной до 10 мм стен</Name>\r\n        <Count>1.44</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>1.44</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table19" msdata:rowOrder="8" diffgr:hasChanges="inserted">\r\n        <Code>101-2430</Code>\r\n        <Name>Грунтовка &lt;Тифенгрунд&gt;, КНАУФ</Name>\r\n        <Count>18.72</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>18.72</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table110" msdata:rowOrder="9" diffgr:hasChanges="inserted">\r\n        <Code>15-01-019-05</Code>\r\n        <Name>Гладкая облицовка стен, столбов, пилястр и откосов (без карнизных, плинтусных и угловых плиток) без установки плиток туалетного гарнитура на клее из сухих смесей по кирпичу и бетону</Name>\r\n        <Count>1.44</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>1.44</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table111" msdata:rowOrder="10" diffgr:hasChanges="inserted">\r\n        <Code>62-39-1</Code>\r\n        <Name>Промывка поверхности, окрашенной масляными красками стен и фасадов</Name>\r\n        <Count>0.87</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>0.87</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table112" msdata:rowOrder="11" diffgr:hasChanges="inserted">\r\n        <Code>61-2-7</Code>\r\n        <Name>Ремонт штукатурки внутренних стен по камню и бетону цементно-известковым раствором, площадью отдельных мест до 1 м2 толщиной слоя до 20 мм</Name>\r\n        <Count>0.87</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>0.87</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table113" msdata:rowOrder="12" diffgr:hasChanges="inserted">\r\n        <Code>15-04-025-08</Code>\r\n        <Name>Улучшенная окраска масляными составами по штукатурке стен</Name>\r\n        <Count>0.87</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>0.87</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table114" msdata:rowOrder="13" diffgr:hasChanges="inserted">\r\n        <Code>62-11-5</Code>\r\n        <Name>Улучшенная масляная окраска ранее окрашенных полов за два раза с расчисткой старой краски до 35%</Name>\r\n        <Count>0.94</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>0.94</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table115" msdata:rowOrder="14" diffgr:hasChanges="inserted">\r\n        <Code>101-2430</Code>\r\n        <Name>Грунтовка &lt;Тифенгрунд&gt;, КНАУФ</Name>\r\n        <Count>1.95</Count>\r\n        <Price>1</Price>\r\n        <Fullprice>1.95</Fullprice>\r\n        <Workprice>1</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table116" msdata:rowOrder="15" diffgr:hasChanges="inserted">\r\n        <Code>11-01-036-01</Code>\r\n        <Name>на клее бустилат</Name>\r\n        <Count>0.33</Count>\r\n        <Price>36500</Price>\r\n        <Fullprice>12045</Fullprice>\r\n        <Workprice>0</Workprice>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table117" msdata:rowOrder="16" diffgr:hasChanges="inserted">\r\n        <Code>15-02-036-01</Code>\r\n        <Name>Штукатурка по сетке без каркаса</Name>\r\n        <Count>0.15</Count>\r\n        <Price>4900</Price>\r\n        <Fullprice>735</Fullprice>\r\n        <Workprice>0</Workprice>\r\n      </Table1>\r\n    </table>\r\n  </diffgr:diffgram>\r\n</DataSet>', '2014-02-05', '2017-05-07', '2018-02-04', '2011-02-07', '2019-02-07', 123, '231', 0),
(36, 'Проект1', 'Гатчина адрес бла блша бла', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" />\r\n</DataSet>', '2018-02-07', '2018-02-08', '2018-02-16', '2018-02-16', '2018-02-15', 123, '231', 0),
(37, 'qwe', 'qwe', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" />\r\n</DataSet>', '2018-02-07', '2018-02-08', '2018-02-16', '2018-02-16', '2018-02-15', 123, '231', 0),
(38, 'ПетергофКрыша', 'Петергоф адрес такойто', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" />\r\n</DataSet>', '2018-02-07', '2018-02-08', '2018-02-16', '2018-02-16', '2018-02-15', 123, '231', 0),
(40, 'qwe', 'qwe', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" />\r\n</DataSet>', '2018-02-07', '2018-02-08', '2018-02-16', '2018-02-16', '2018-02-15', 123, '231', 0),
(41, 'Невский 152', 'СПБ Невский 152', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">\r\n    <table>\r\n      <Table1 diffgr:id="Table11" msdata:rowOrder="0" diffgr:hasChanges="inserted">\r\n        <Name>Демонтаж напольных покрытий(с плинтусами) паркетных</Name>\r\n        <Count>6</Count>\r\n        <Price>0</Price>\r\n      </Table1>\r\n      <Table1 diffgr:id="Table12" msdata:rowOrder="1" diffgr:hasChanges="inserted">\r\n        <Name>Цементно-песчаная стяжка (с разборкой) на кирпичном щебне</Name>\r\n        <Count>6</Count>\r\n        <Price>27600</Price>\r\n      </Table1>\r\n    </table>\r\n  </diffgr:diffgram>\r\n</DataSet>', '2018-02-07', '2018-02-08', '2018-02-16', '2018-02-16', '2018-02-15', 123, '231', 0),
(42, 'СТАКАТ', 'Гор. Санкт-Петербург, пр. карла-маркса, дом 52, корпус 3, помещение 201F', '<?xml version="1.0" encoding="utf-8"?>\r\n<DataSet>\r\n  <xs:schema id="table" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">\r\n    <xs:element name="table" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">\r\n      <xs:complexType>\r\n        <xs:choice minOccurs="0" maxOccurs="unbounded">\r\n          <xs:element name="Table1">\r\n            <xs:complexType>\r\n              <xs:sequence>\r\n                <xs:element name="Name" type="xs:string" minOccurs="0" />\r\n                <xs:element name="Count" type="xs:double" minOccurs="0" />\r\n                <xs:element name="Price" type="xs:double" minOccurs="0" />\r\n              </xs:sequence>\r\n            </xs:complexType>\r\n          </xs:element>\r\n        </xs:choice>\r\n      </xs:complexType>\r\n    </xs:element>\r\n  </xs:schema>\r\n  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">\r\n    <table>\r\n      <Table1 diffgr:id="Table11" msdata:rowOrder="0" diffgr:hasChanges="inserted">\r\n        <Name>Грунтование водно-дисперсионной грунтовкой "Нортекс-Грунт" поверхностей: </Name>\r\n        <Count>5</Count>\r\n        <Price>3360</Price>\r\n      </Table1>\r\n    </table>\r\n  </diffgr:diffgram>\r\n</DataSet>', '2017-07-27', '2018-04-13', '2018-07-15', '2018-09-15', '2018-07-14', 0, NULL, 0);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Crew`
--
ALTER TABLE `Crew`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_2` (`id`),
  ADD KEY `id` (`id`);

--
-- Индексы таблицы `JobKind`
--
ALTER TABLE `JobKind`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `Manager`
--
ALTER TABLE `Manager`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Matherials`
--
ALTER TABLE `Matherials`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Object`
--
ALTER TABLE `Object`
  ADD PRIMARY KEY (`id`),
  ADD KEY `crew` (`crew`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Crew`
--
ALTER TABLE `Crew`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT для таблицы `Manager`
--
ALTER TABLE `Manager`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'id';
--
-- AUTO_INCREMENT для таблицы `Matherials`
--
ALTER TABLE `Matherials`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1628;
--
-- AUTO_INCREMENT для таблицы `Object`
--
ALTER TABLE `Object`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'стандартный id',AUTO_INCREMENT=43;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
