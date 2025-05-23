UPDATE anthems SET motto = data.motto FROM ( VALUES
(1, 'There is no god but Allah, Muhammad is the messenger of Allah'),
(2, 'Liberty, Equality, Fraternity'),
(3, 'Unity and Justice and Freedom'),
(4, 'Virtus Unita Fortior'),
(5, 'Angola, Avante!'),
(6, 'Each endeavored for the good of the other'),
(7, 'En unión y libertad'),
(8, 'Honor to the Country, Love to the Homeland'),
(9, 'Advance Australia Fair'),
(10, 'Austria above all'),
(11, 'Azerbaijan, Azerbaijan, Azerbaijan'),
(12, 'Forward, Bahamas'),
(13, 'Bahrain, Land of Light'),
(14, 'The March of the Patriots'),
(15, 'In the Time of the British Crown'),
(16, 'In Union, There is Strength'),
(17, 'Union is Strength'),
(18, 'We Shall Win'),
(19, 'Viva Bolivia'),
(20, 'Land of the Free, Home of the Brave'),
(21, 'Pula! Let us unite in peace and friendship'),
(22, 'Order and Progress'),
(23, 'Brunei Darussalam, The Abode of Peace'),
(24, 'Unity in Diversity'),
(25, 'Happy is the nation that is content'),
(26, 'Unity in Strength'),
(27, 'Freedom, Peace and Justice'),
(28, 'Nationhood in Peace and Prosperity'),
(29, 'Unity, Peace, Prosperity'),
(30, 'True North, Strong and Free'),
(31, 'By reason and faith'),
(32, 'Strive to strengthen the unity'),
(33, 'Freedom and Honour'),
(34, 'Liberty, Equality, and Fraternity'),
(35, 'Unity, Peace, Prosperity'),
(36, 'Let the People Arise'),
(37, 'Unite, for the South'),
(38, 'Pure Costa Rica'),
(39, 'In Unity, We Stand'),
(40, 'Patria o Muerte, Venceremos'),
(41, 'Prosperity with Peace and Justice'),
(42, 'God and Country'),
(43, 'After Freedom, Service'),
(44, 'The Rights of All'),
(45, 'Freedom and Dignity'),
(46, 'Peace, Liberty, and Independence'),
(47, 'Work and Progress'),
(48, 'Long live Spain, Spain'),
(49, 'In God We Trust'),
(50, 'Through Unity and Strength'),
(51, 'God, Our Guide'),
(52, 'Ethiopia Shall Rise'),
(53, 'To Be Strong and Free'),
(54, 'Our Land, Our Heritage'),
(55, 'Peace and Prosperity'),
(56, 'Liberty, Equality, Fraternity'),
(57, 'In Liberty We Live'),
(58, 'Victory Over Evil'),
(59, 'Strength Through Unity'),
(60, 'Freedom and Independence'),
(61, 'Freedom or Death'),
(62, 'Better Life for All'),
(63, 'Unity in Strength'),
(64, 'We Will Prosper'),
(65, 'Freedom for All'),
(66, 'Unity and Freedom'),
(67, 'Together We Rise'),
(68, 'God is Great'),
(69, 'A Nation for All'),
(70, 'Forward, Together'),
(71, 'Unity and Discipline'),
(72, 'Unity in Diversity'),
(73, 'Strength, Unity, Peace'),
(74, 'Our Land, Our People'),
(75, 'To Serve the People'),
(76, 'Building the Future Together'),
(77, 'Unity in Diversity'),
(78, 'Freedom and Democracy'),
(79, 'Labor is Our Duty'),
(80, 'Together We Build the Future'),
(81, 'Strength, Unity, Progress'),
(82, 'Harmony, Prosperity, Peace'),
(83, 'Freedom, Justice, Unity'),
(84, 'Unity and Peace'),
(85, 'Live with Faith'),
(86, 'With Pride, We Stand'),
(87, 'We are One'),
(88, 'Freedom in Diversity'),
(89, 'Together We Rise'),
(90, 'Pride, Strength, and Honor'),
(91, 'We are One People'),
(92, 'Liberty, Peace, and Unity'),
(93, 'The Nation and Unity'),
(94, 'The Land of the Free'),
(95, 'Power and Unity'),
(96, 'Unity, Peace, Progress'),
(97, 'We Are One People'),
(98, 'Strength, Peace, and Unity'),
(99, 'One People, One Nation'),
(100, 'For the People, By the People'),
(101, 'A Strong Nation, One People'),
(102, 'In Unity, We Build'),
(103, 'Independence and Prosperity'),
(104, 'Strength, Unity, and Freedom'),
(105, 'In Unity, We Find Strength'),
(106, 'Strength in Unity'),
(107, 'Together for the Future'),
(108, 'Freedom, Unity, and Peace'),
(109, 'Unity, Strength, Prosperity'),
(110, 'We Are Stronger Together'),
(111, 'Unity in Diversity'),
(112, 'One People, One Nation'),
(113, 'Strength, Unity, and Peace'),
(114, 'Together, We Stand Strong'),
(115, 'Unity for Prosperity'),
(116, 'Strength and Unity'),
(117, 'Strength, Peace, and Prosperity'),
(118, 'Unity and Strength'),
(119, 'Strength in Unity'),
(120, 'Live Free and Prosper'),
(121, 'Strength and Unity in Diversity'),
(122, 'Unity, Strength, and Prosperity'),
(123, 'Freedom, Unity, and Justice'),
(124, 'Peace, Unity, and Progress'),
(125, 'In Unity, We Stand'),
(126, 'United for Peace'),
(127, 'Unity, Strength, and Progress'),
(128, 'Freedom and Progress'),
(129, 'Unity, Strength, and Liberty'),
(130, 'Unity in Peace'),
(131, 'Unity, Freedom, and Strength'),
(132, 'Stronger Together'),
(133, 'Liberty, Unity, and Progress'),
(134, 'Strength, Freedom, Unity'),
(135, 'Together We Rise'),
(136, 'Unity and Strength in Diversity'),
(137, 'Strength in Diversity'),
(138, 'Freedom and Unity'),
(139, 'Strength, Unity, and Hope'),
(140, 'Unity, Strength, and Prosperity'),
(141, 'Peace and Prosperity'),
(142, 'Unity, Liberty, and Peace'),
(143, 'Strength and Unity'),
(144, 'Strength and Unity for Progress'),
(145, 'Unity and Peace for Development'),
(146, 'Peace, Liberty, and Unity'),
(147, 'Unity and Peace for Prosperity'),
(148, 'Unity and Strength in Action'),
(149, 'Unity, Peace, and Prosperity'),
(150, 'Unity and Strength'),
(151, 'Unity in Diversity'),
(152, 'Freedom, Unity, and Strength'),
(153, 'Unity and Prosperity'),
(154, 'Strength, Unity, and Peace'),
(155, 'Unity, Strength, and Development'),
(156, 'Peace, Unity, and Progress'),
(157, 'Together for Strength and Prosperity'),
(158, 'Strength, Unity, and Justice'),
(159, 'Unity for Peace and Progress'),
(160, 'Unity, Peace, and Progress'),
(161, 'Strength and Prosperity'),
(162, 'Peace and Unity'),
(163, 'Peace and Unity for Development'),
(164, 'Unity, Peace, and Strength'),
(165, 'Strength and Unity'),
(166, 'Strength, Unity, and Peace'),
(167, 'Unity for Peace and Justice'),
(168, 'Strength, Unity, and Development'),
(169, 'Unity for Peace')
) AS data(id, motto)
WHERE anthems.id = data.id;
