namespace TheAncientMerch.Data.Seeding
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using TheAncientMerch.Data.Models;

    public class GreekDeitySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            // Enum.Parse<ExerciseDifficulty>("Intermediate")
            if (dbContext.GreekDeities.Any())
            {
                return;
            }

            var greekDeities = new List<GreekDeity>
            {
                new GreekDeity
                {
                    Name = "Zeus",
                    ImageUrl = "https://www.theoi.com/image/K1.1Zeus.jpg",
                    Description = @"ZEUS (Zeus), the greatest of the Olympian gods, and the father of gods and men, was a son of Cronos and Rhea, a brother of Poseidon, Hades (Pluto), Hestia, Demeter, Hera, and at the same time married to his sister Hera. When Zeus and his brothers distributed among themselves the government of the world by lot, Poseidon obtained the sea, Hades the lower world, and Zeus the heavens and the upper regions, but the earth became common to all (Hom. Il. xv. 187, &c., i. 528, ii. 111; Virg. Aen. iv. 372).
Later mythologers enumerate three Zeus in their genealogies two Arcadian ones and one Cretan; and tne first is said to be a son of Aether, the second of Coelus, and the third of Saturnus (Cic. de Nat. Deor. iii. 21). This accounts for the fact that some writers use the name of the king of heaven who sends dew, rain, snow, thunder, and lightning for heaven itself in its physical sense. (Horat. Carm. i. 1. 25 ; Virg. Georg. ii. 419.)
According to the Homeric account Zeus, like the other Olympian gods, dwelt on Mount Olympus in Thessaly, which was believed to penetrate with its lofty summit into heaven itself (Il. i. 221, &c., 354, 609, xxi. 438). He is called the father of gods and men (i. 514, v. 33; comp. Aeschyl. Sept. 512), the most high and powerful among the immortals, whom all others obey (Il. xix. 258, viii. 10, &c.). He is the highest ruler, who with his counsel manages every thing (i. 175, viii. 22), the founder of kingly power, of law and of order, whence Dice, Themis and Nemesis are his assistants (i. 238, ii. 205, ix. 99, xvi. 387; comp. Hes. Op. et D. 36 ; Callim. Hymn. in Jov. 79).
For the same reason he protects the assembly of the people (agoraios), the meetings of the council (boulaios), and as he presides over the whole state, so also over every house and family (herkeios, Od. xxii. 335; comp. Ov. Ib. 285). He also watched over the sanctity of the oath (horkios), the law of hospitality (xenios), and protected suppliants (hikesios, Od. ix. 270; comp. Paus. v. 24. § 2). He avenged those who were wronged, and punished those who had committed a crime, for he watched the doings and sufferings of all men (epopsios, Od. xiii. 213; comp. Apollon. Rhod. i. 1123).
He was further the original source of all prophetic power, front whom all prophetic signs and sounds proceeded (panomphaios, Il. viii. 250 ; comp. Aeschyl. Eum. 19 ; Callim. Hymn. in Jov. 69). Every thing good as well as bad comes from Zeus, and according to his own choice he assigns their good or evil lot to mortals (Od. iv. 237, vi. 188, ix. 552, Il. x. 71, xvii. 632, &c.), and fate itself was subordinate to him.
He is armed with thunder and lightning, and the shaking of his aegis produces storm and tempest (Il. xvii. 593) : a number of epithets of Zeus in the Homeric poems describe him as the thunderer, the gatherer of clouds, and the like.
He was married to Hera, by whom he had two sons, Ares and Hephaestus, and one daughter, Hebe (Il. i. 585, v. 896, Od. xi. 604). Hera sometimes acts as an independent divinity, she is ambitious and rebels against her lord, but she is nevertheless inferior to him, and is punished for her opposition (Il. xv. 17, &c., xix. 95, &c.) ; his amours with other goddesses or mortal women are not concealed from her, though they generally rouse her jealousy and revenge (Il. xiv. 317). During the Trojan war, Zeus, at the request of Thetis, favoured the Trojans, until Agamemnon made good the wrong he had done to Achilles.
Zeus, no doubt, was originally a god of a portion of nature, whence the oak with its eatable fruit and the fertile doves were sacred to him at Dodona and in Arcadia (hence also rain, storms, and the seasons were regarded as his work, and hence the Cretan stories of milk, honey, and cornucopia) ; but in the Homeric poems, this primitive character of a personification of certain powers of nature is already effaced to some extent, and the god appears as a political and national divinity, as the king and father of men, as the founder and protector of all institutions hallowed by law, custom. or religion.
Hesiod (Theog. 116, &c.) also calls Zeus the son of Cronos and Rhea , and the brother of Hestia, Demeter, Hera, Hades, and Poseidon. Cronos swallowed his children immediately after their birth, but when Rhea was near giving birth to Zeus, she applied to Uranus and Ge for advice as to how the child might be saved. Before the hour of birth came, Uranus and Ge sent Rhea to Lyctos in Crete, requesting her to bring up her child there. Rhea accordingly concealed her infant in a cave of Mount Aegaeon, and gave to Cronos a stone wrapped up in cloth, which he swallowed in the belief that it was his son. Other traditions state that Zeus was born and brought up on Mount Dicte or Ida (also the Trojan Ida), Ithome in Messenia, Thebes in Boeotia, Aegion in Achaia, or Olenos in Aetolia. According to the common account, however, Zeus grew up in Crete. As Rhea is sometimes identified with Ge, Zeus is also called a son of Ge. (Aeschyl. Suppl. 901.)
In the meantime Cronos by a cunning device of Ge or Metis was made to bring up the children he had swallowed, and first of all the stone, which was afterwards set up by Zeus at Delphi. The young god now delivered the Cyclopes from the bonds with which they had been fettered by Cronos, and they in their gratitude provided him with thunder and lightning. On the advice of Ge. Zeus also liberated the hundred-armed Gigantes, Briareos, Cottus, and Gyes, that they might assist him in his fight against the Titans. (Apollod. i. 2. § 1; Hes. Theog. 617, &c.) The Titans were conquered and shut up in Tartarus (Theog. 717), where they were henceforth guarded by the Hecatoncheires. Thereupon Tartarus and Ge begot Typhoeus, who began a fearful struggle with Zeus, but was conquered. (Theog. 820, &c.)
Zeus now obtained the dominion of the world, and chose Metis for his wife. (Theog. 881, &c.) When she was pregnant with Athena, he took the child out of her body and concealed it in his own, on the advice of Uranus and Ge, who told him that thereby he would retain the supremacy of the world. For Metis had given birth to a son, this son (so fate had ordained it) would have acquired the sovereignty. After this Zeus, by his second wife Themis. became the father of the Horae and Moerae; of the Charites by Eurynome, of Persephone by Demeter, of the Muses by Mnemosyne, of Apollo and Artemis by Leto, and of Hebe, Ares, and Eileithyia by Hera. Athena was born out of the head of Zeus; while Hera, on the other hand, gave birth to Hephaestus without the co-operation of Zeus. (Theog. 8866, &c.)
The family of the Cronidae accordingly embraces the twelve great gods of Olympus, Zeus (the head of them all), Poseidon, Apollo, Ares, Hermes, Hephaestus, Hestia, Demeter, Hera, Athena, Aphrodite, and Artemis. These twelve Olympian gods, who in some places were worshipped as a body, as at Athens (Thueyd. vi. 54), were recognised not only by the Greeks, but were adopted also by the Romans, who, in particular, identified their Jupiter with the Greek Zeus.
In surveying the different local traditions about Zeus, it would seem that originally there were several, at least three, divinities which in their respective countries were supreme, but which in the course of time became united in the minds of tile people into one great national divinity. We may accordingly speak of an Arcadian, Dodonaean, Cretan, and a national Hellenic Zeus.
1. The Arcadian Zeus (Zeus Lukaios) was born, according to the legends of the country, in Arcadia, either on Mount Parrhasion (Callim. Hymn. in Jov. 7, 10), or in a district of Mount Lycaeon, which was called Cretea. (Paus. viii. 38. § 1 ; Callim. l. c. 14.) He was brought up there by the nymphs Theisoa, Neda, and Hagno; the first of these gave her name to an Arcadian town, the second to a river, and the third to a well. (Paus. viii. 38. § 2, &c., 47. § 2; comp. Callim. l. c. 33.) Lycaon, a son of Pelasgus, who built the first and most ancient town of Lycosura, called Zeus Lycaeus, and erected a temple and instituted the festival of the Lyceia in honour of him; he further offered to him bloody sacrifices, and among others his own son, in consequence of which he was metamorphosed into a wolf (lukos; Paus. viii. 2. § 1, 38. § 1; Callim. l. c. 4 ; Ov. Met. i. 218.) No one was allowed to enter the sanctuary of Zeus Lycaeus on Mount Lycaeon, and there was a belief that, if any one entered it, he died within twelve months after, and that in it neither human beings nor animals cast a shadow. (Paus. viii. 38. § 5; comp. Schol. ad Callim. Hymn. in Jov. 13.) Those who entered it intentionally were stoned to death, unless they escaped by flight; and those who had got in by accident were sent to Eleutherae. (Plut. Quaest. Gr. 39.) On the highest summit of Lycaeon, there was an altar of Zeus, in front of which, towards the east, there were two pillars bearing golden eagles. The sacrifices offered there were kept secret. (Paus. viii. 38. § 5; Callim. l. c. 68.)
2. The Dodonaean Zeus (Zeus Dôdônaios or Pelasgikos) possessed the most ancient oracle in Greece, at Dodona in Epeirus, near mount Tomarus (Tmarus or Tomurus), from which he derived his name. (Hom. Il. ii. 750, xvi. 233; Herod. ii. 52 ; Paus. i. 17. § 5; Strab. v. p. 338, vi. p. 504; Virg. Eclog. viii. 44.) At Dodona Zeus was mainly a prophetic god, and the oak tree was sacred to him ; but there too he was said to have been reared by if the Dodonaean nymphs (Hyades; Schol. ad Hom. Il. xviii. 486; Hygin. Fab. 182 ; Ov. Fast. vi. 711, Met. iii. 314). Respecting the Dodonaean oracle of Zeus, see Dict. of Ant. s. v. Oraculum.
3. The Cretan Zeus (Zeus Diktaios or Krêtagenês). We have already given the account of him which is contained in the Theogony of Hesiod. He is the god, to whom Rhea, concealed from Cronos, gave birth in a cave of mount Dicte, and whom she entrusted to the Curetes and the nymphs Adrasteia and Ida, the daughters of Melisseus. They fed him with milk of the goat Amaltheia, and the bees of the mountain provided him with honey. (Apollod. i. 1. § 6; Callim. l. c. ; Diod. v. 70; comp. Athen. xi. 70; Ov. Fast. v. 115.) Crete is called the island or nurse of the great Zeus, and his worship there appears to have been very ancient. (Virg. Aen. iii. 104; Dionys. Perieg. 501.) Among the places in the island which were particularly sacred to the god, we must mention the district about mount Ida, especially Cnosus, which was said to have been built by the Curetes, and where Minos had ruled and conversed with Zeus (Hom. Od. xix. 172; Plat. de Leg. i. 1; Diod. v. 70; Strab. x. p. 730; Cic. de Nat. Deor. iii. 21); Gortyn, where the god, in the form of a bull, landed when he had carried off Europa from Phoenicia, and where he was worshipped under the surname of Hecatombaeus (Hesych. s. v.) ; further the towns about mount Dicte, as Lyctos (Hes. Theog. 477), Praesos, Hierapytna, Biennos, Eleuthernae and Oaxus. (Comp. Hoeck, Creta, i. p. 160, &c., 339, &c.)
4. The national Hellenic Zeus, near whose temple at Olympia in Elis, the great national panegyris was celebrated every fifth year. There too Zeus was regarded as the father and king of gods and men, and as the supreme god of the Hellenic nation, His statue there was executed by Pheidias, a few years before the outbreak of the Peloponnesian war, the majestic and sublime idea for this statue having been suggested to the artist by the words of Homer, Il. i. 527. (Comp. Hygin. Fab. 223.) According to the traditions of Elis, Cronos was the first ruler of the country, and in the golden age there was a temple dedicated to him at Olympia. Rhea, it is further said, entrusted the infant Zeus to the Idaean Dactyls, who were also called Curetes, and had come from mount Ida in Crete to Elis. Heracles, one of them, contended with his brother Dactyls in a footrace, and adorned the victor with a wreath of olive. In this manner he is said to have founded the Olympian games, and Zeus to have contended with Cronos for the kingdom of Elis. (Paus. v. 7. § 4.)
The Greek and Latin poets give to Zeus an immense number of epithets and surnames, which are derived partly from the places where he was worshipped, and partly from his powers and functions. He was worshipped throughout Greece and her colonies, so that it would be useless and almost impossible to enumerate all the places.
The eagle, the oak, and the summits of mountains were sacred to him, and his sacrifices generally consisted of goats, bulls and cows. (Hom. Il. ii. 403; Aristot. Ethic. v. 10, ix. 2; Virg. Aen. iii. 21, ix. 627.) His usual attributes are, the sceptre, eagle, thunderbolt, and a figure of Victory in his hand, and sometimes also a cornucopia. The Olympian Zeus sometimes wears a wreath of olive, and the Dodonaean Zeus a wreath of oak leaves.
In works of art Zeus is generally represented as the omnipotent father and king of gods and men, according to the idea which had been embodied in the statue of the Olympian Zeus by Pheidias.
Source: Dictionary of Greek and Roman Biography and Mythology.",
                    VideoUrl = "https://www.youtube.com/watch?v=SdIVEG7UeBg",
                    Type = Enum.Parse<DeityType>("God"),
                },

                new GreekDeity
                {
                    Name = "Poseidon",
                    ImageUrl = "https://www.theoi.com/image/Z2.11Poseidon.jpg",
                    Description = @"Poseidon (/pəˈsaɪdən, pɒ-, poʊ-/;[1] Greek: Ποσειδῶν) was one of the Twelve Olympians in ancient Greek religion and myth, god of the sea, storms, earthquakes and horses. In pre-Olympian Bronze Age Greece, he was venerated as a chief deity at Pylos and Thebes. He also had the cult title ""earth shaker\"". In the myths of isolated Arcadia he is related with Demeter and Persephone and he was venerated as a horse, however it seems that he was originally a god of the waters. He is often regarded as the tamer or father of horses, and with a strike of his trident, he created springs which are related with the word horse. His Roman equivalent is Neptune.

Poseidon was protector of seafarers, and of many Hellenic cities and colonies. Homer and Hesiod suggest that Poseidon became lord of the sea following the defeat of his father Cronus, when the world was divided by lot among his three sons; Zeus was given the sky, Hades the underworld, and Poseidon the sea, with the Earth and Mount Olympus belonging to all three.In Homer's Iliad, Poseidon supports the Greeks against the Trojans during the Trojan War and in the Odyssey, during the sea-voyage from Troy back home to Ithaca, the Greek hero Odysseus provokes Poseidon's fury by blinding his son, the Cyclops Polyphemus, resulting in Poseidon punishing him with storms, the complete loss of his ship and companions, and a ten-year delay.Poseidon is also the subject of a Homeric hymn.In Plato's Timaeus and Critias, the legendary island of Atlantis was Poseidon's domain.

Athena became the patron goddess of the city of Athens after a competition with Poseidon, and he remained on the Acropolis in the form of his surrogate, Erechtheus.After the fight, Poseidon sent a monstrous flood to the Attic Plain, to punish the Athenians for not choosing him.",
                    VideoUrl = "https://www.youtube.com/watch?v=0CrPPxDpCA4",
                    Type = Enum.Parse<DeityType>("God"),
                },

                new GreekDeity
                {
                    Name = "Hermes",
                    ImageUrl = "https://www.theoi.com/image/K11.11Hermes.jpg",
                    Description = @"Hermes (/ˈhɜːrmiːz/; Greek: Ἑρμῆς) is an Olympian deity in ancient Greek religion and mythology. Hermes is considered the herald of the gods. He is also considered the protector of human heralds, travellers, thieves, merchants, and orators. He is able to move quickly and freely between the worlds of the mortal and the divine, aided by his winged sandals. Hermes plays the role of the psychopomp or ""soul guide""—a conductor of souls into the afterlife.

In myth, Hermes functioned as the emissary and messenger of the gods, and was often presented as the son of Zeus and Maia, the Pleiad. He is regarded as ""the divine trickster,"" about which the Homeric Hymn to Hermes offers the most well-known account.

His attributes and symbols include the herma, the rooster, the tortoise, satchel or pouch, talaria (winged sandals), and winged helmet or simple petasos, as well as the palm tree, goat, the number four, several kinds of fish, and incense. However, his main symbol is the caduceus, a winged staff intertwined with two snakes copulating and carvings of the other gods. His attributes had previously influenced the earlier Etruscan god Turms, a name borrowed from the Greek ""herma"".

In Roman mythology, Hermes was known as Mercury, a name derived from the Latin merx, meaning ""merchandise,"" and the origin of the words ""merchant"" and ""commerce.""",
                    VideoUrl = "https://www.youtube.com/watch?v=GqupoGuixqM",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Hera",
                    ImageUrl = "https://www.theoi.com/image/K4.7Hera.jpg",
                    Description = @"Hera (/ˈhɛrə, ˈhɪərə/; Greek: Ἥρα, translit. Hḗrā; Ἥρη, Hḗrē in Ionic and Homeric Greek) is the goddess of women, marriage, family and childbirth in ancient Greek religion and mythology, one of the twelve Olympians and the sister and wife of Zeus. She is the daughter of the Titans Cronus and Rhea. Hera rules over Mount Olympus as queen of the gods. A matronly figure, Hera served as both the patroness and protectress of married women, presiding over weddings and blessing marital unions. One of Hera's defining characteristics is her jealous and vengeful nature against Zeus' numerous lovers and illegitimate offspring, as well as the mortals who cross her.

Hera on an antique fresco from Pompeii
Hera is commonly seen with the animals she considers sacred, including the cow, lion and the peacock. Portrayed as majestic and solemn, often enthroned, and crowned with the polos (a high cylindrical crown worn by several of the Great Goddesses), Hera may hold a pomegranate in her hand, emblem of fertile blood and death and a substitute for the narcotic capsule of the opium poppy.

Her Roman counterpart is Juno.",
                    VideoUrl = "https://www.youtube.com/watch?v=u1UyQrJIBjA",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Hephaestus",
                    ImageUrl = "https://www.theoi.com/image/K7.1Hephaistos.jpg",
                    Description = @"Hephaestus (/hɪˈfiːstəs, hɪˈfɛstəs/; eight spellings; Greek: Ἥφαιστος, translit. Hḗphaistos) is the Greek god of blacksmiths, metalworking, carpenters, craftsmen, artisans, sculptors, metallurgy, fire (compare, however, with Hestia), and volcanoes. Hephaestus's Roman counterpart is Vulcan. In Greek mythology, Hephaestus was either the son of Zeus and Hera or he was Hera's parthenogenous child. He was cast off Mount Olympus by his mother Hera because of his lameness, the result of a congenital impairment; or in another account, by Zeus for protecting Hera from his advances (in which case his lameness would have been the result of his fall rather than the reason for it).

As a smithing god, Hephaestus made all the weapons of the gods in Olympus. He served as the blacksmith of the gods, and was worshipped in the manufacturing and industrial centres of Greece, particularly Athens. The cult of Hephaestus was based in Lemnos. Hephaestus's symbols are a smith's hammer, anvil, and a pair of tongs.",
                    VideoUrl = "https://www.youtube.com/watch?v=RhVkmTrt44U",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Dionysus",
                    ImageUrl = "https://www.theoi.com/image/Z12.1Dionysos.jpg",
                    Description = @"Dionysus (/daɪ.əˈnaɪsəs/; Greek: Διόνυσος Dionysos) is the god of the grape-harvest, winemaking, orchards and fruit, vegetation, fertility, insanity, ritual madness, religious ecstasy, festivity and theatre in ancient Greek religion and myth. He is also known as Bacchus (/ˈbækəs/ or /ˈbɑːkəs/; Greek: Βάκχος Bacchos), the name adopted by the Romans; the frenzy that he induces is bakkheia. As Eleutherios (""the liberator""), his wine, music and ecstatic dance free his followers from self-conscious fear and care, and subvert the oppressive restraints of the powerful. His thyrsus, a fennel-stem sceptre, sometimes wound with ivy and dripping with honey, is both a beneficent wand and a weapon used to destroy those who oppose his cult and the freedoms he represents. Those who partake of his mysteries are believed to become possessed and empowered by the god himself.

His origins are uncertain, and his cults took many forms; some are described by ancient sources as Thracian, others as Greek. In Orphic religion, he was variously a son of Zeus and Persephone; a chthonic or underworld aspect of Zeus; or the twice-born son of Zeus and the mortal Semele. The Eleusinian Mysteries identify him with Iacchus, the son or husband of Demeter. Most accounts say he was born in Thrace, traveled abroad, and arrived in Greece as a foreigner. His attribute of ""foreignness"" as an arriving outsider-god may be inherent and essential to his cults, as he is a god of epiphany, sometimes called ""the god that comes"".

Wine was a religious focus in the cult of Dionysus and was his earthly incarnation. Wine could ease suffering, bring joy, and inspire divine madness. Festivals of Dionysus included the performance of sacred dramas enacting his myths, the initial driving force behind the development of theatre in Western culture. The cult of Dionysus is also a ""cult of the souls""; his maenads feed the dead through blood-offerings, and he acts as a divine communicant between the living and the dead. He is sometimes categorised as a dying-and-rising god.

Romans identified Bacchus with their own Liber Pater, the ""Free Father"" of the Liberalia festival, patron of viniculture, wine and male fertility, and guardian of the traditions, rituals and freedoms attached to coming of age and citizenship, but the Roman state treated independent, popular festivals of Bacchus (Bacchanalia) as subversive, partly because their free mixing of classes and genders transgressed traditional social and moral constraints. Celebration of the Bacchanalia was made a capital offence, except in the toned-down forms and greatly diminished congregations approved and supervised by the State. Festivals of Bacchus were merged with those of Liber and Dionysus.",
                    VideoUrl = "https://www.youtube.com/watch?v=VTTx21E0ceQ",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Demeter",
                    ImageUrl = "https://www.theoi.com/image/K26.1Ploutos.jpg",
                    Description = @"In ancient Greek religion and mythology, Demeter (/dɛˈmiːtər/; Attic: Δημήτηρ Dēmḗtēr [dɛːmɛ́ːtɛːr]; Doric: Δαμάτηρ Dāmā́tēr) is the Olympian goddess of the harvest and agriculture, presiding over grains and the fertility of the earth. She is also called Deo (Δηώ).

Her cult titles include Sito (Σιτώ), ""she of the Grain"", as the giver of food or grain, and Thesmophoros (θεσμός, thesmos: divine order, unwritten law; φόρος, phoros: bringer, bearer), ""giver of customs"" or ""legislator"", in association with the secret female-only festival called the Thesmophoria.

Though Demeter is often described simply as the goddess of the harvest, she presided also over the sacred law, and the cycle of life and death. She and her daughter Persephone were the central figures of the Eleusinian Mysteries, a religious tradition that predated the Olympian pantheon, and which may have its roots in the Mycenaean period c. 1400–1200 BC. One of the most notable Homeric Hymns, the Homeric Hymn to Demeter, tells the story of Persephone's abduction by Hades and Demeter's search for her.

Demeter was often considered to be the same figure as the Anatolian goddess Cybele, and she was identified with the Roman goddess Ceres.",
                    VideoUrl = "https://www.youtube.com/watch?v=_GXFQqngY7w",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Athena",
                    ImageUrl = "https://www.theoi.com/image/K8.3Athena.jpg",
                    Description = @"Athena or Athene, often given the epithet Pallas, is an ancient Greek goddess associated with wisdom, handicraft, and warfare who was later syncretized with the Roman goddess Minerva. Athena was regarded as the patron and protectress of various cities across Greece, particularly the city of Athens, from which she most likely received her name. The Parthenon on the Acropolis of Athens is dedicated to her. Her major symbols include owls, olive trees, snakes, and the Gorgoneion. In art, she is generally depicted wearing a helmet and holding a spear.

From her origin as an Aegean palace goddess, Athena was closely associated with the city. She was known as Polias and Poliouchos (both derived from polis, meaning ""city-state""), and her temples were usually located atop the fortified acropolis in the central part of the city. The Parthenon on the Athenian Acropolis is dedicated to her, along with numerous other temples and monuments. As the patron of craft and weaving, Athena was known as Ergane. She was also a warrior goddess, and was believed to lead soldiers into battle as Athena Promachos. Her main festival in Athens was the Panathenaia, which was celebrated during the month of Hekatombaion in midsummer and was the most important festival on the Athenian calendar.

In Greek mythology, Athena was believed to have been born from the forehead of her father Zeus. In some versions of the story, Athena has no mother and is born from Zeus' forehead by parthenogenesis. In others, such as Hesiod's Theogony, Zeus swallows his consort Metis, who was pregnant with Athena; in this version, Athena is first born within Zeus and then escapes from his body through his forehead. In the founding myth of Athens, Athena bested Poseidon in a competition over patronage of the city by creating the first olive tree. She was known as Athena Parthenos ""Athena the Virgin,"" but in one archaic Attic myth, the god Hephaestus tried and failed to rape her, resulting in Gaia giving birth to Erichthonius, an important Athenian founding hero. Athena was the patron goddess of heroic endeavor; she was believed to have aided the heroes Perseus, Heracles, Bellerophon, and Jason. Along with Aphrodite and Hera, Athena was one of the three goddesses whose feud resulted in the beginning of the Trojan War.

She plays an active role in the Iliad, in which she assists the Achaeans and, in the Odyssey, she is the divine counselor to Odysseus. In the later writings of the Roman poet Ovid, Athena was said to have competed against the mortal Arachne in a weaving competition, afterward transforming Arachne into the first spider; Ovid also describes how she transformed Medusa into a Gorgon after witnessing her being raped by Poseidon in her temple. Since the Renaissance, Athena has become an international symbol of wisdom, the arts, and classical learning. Western artists and allegorists have often used Athena as a symbol of freedom and democracy.",
                    VideoUrl = "https://www.youtube.com/watch?v=lMh35RX2tZA",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Artemis",
                    ImageUrl = "https://www.theoi.com/image/K6.1Artemis.jpg",
                    Description = @"In Greek mythology and religion, Artemis (/ˈɑːrtɛmɪs/; Greek: Ἄρτεμις) is the goddess of the hunt, the wilderness, wild animals, nature, vegetation, childbirth, the Moon, and chastity. She would often roam the forests of Greece, attended by her large entourage, mostly made up by nymphs, some mortals and hunters. The countryside goddess Diana is her Roman equivalent.

In Greek tradition, Artemis is the daughter of the sky god and king of gods Zeus and Leto, and the twin sister of Apollo. In most accounts, the twins are the products of an extramarital liaison. For this, Zeus' wife Hera forbade Leto from giving birth anywhere on land. Only the island of Delos gave refuge to Leto, allowing her to give birth to her children. Usually, Artemis is the twin to be born first, who then procceeded to assist Leto in the birth of the second child, Apollo. Like her brother, she was a kourotrophic deity, that is the patron and protector of young children, especially girls, and women, and was believed to both bring disease upon women and children and relieve them of it. Artemis was worshipped as one of the primary goddesses of childbirth and midwifery along with Eileithyia and Hera. Much like Athena and Hestia, Artemis preferred to remain a maiden goddess and was sworn never to marry, and was thus one of the three Greek virgin goddesses, over whom the goddess of love and lust, Aphrodite, had no power whatsoever.

In myth and literature, Artemis is presented as a hunting goddess of the woods, surrounded by her followers, who is not to be crossed. In the myth of Actaeon, when the young hunter sees her bathing naked, he is transformed into a deer by the angered goddess, and then devoured by his own hunting dogs who cannot tell their own master. In the story of Callisto, the girl is driven away from Artemis' company after breaking her vow of virginity, having laid with and been impregnated by Zeus. In certain versions, Artemis is the one to turn Callisto into a bear, or even kill her, for the insolence.

In the Epic tradition, Artemis halted the winds blowing the Greek ships during the Trojan War, stranding the Greek fleet in Aulis, after King Agamemnon, the leader of the expedition, shot and killed her sacred deer. Artemis demanded the sacrifice of Iphigenia, Agamemnon's young daughter, as compensation for her slain deer. In most versions, when Iphigenia is led to the altar to be offered as sacrifice, Artemis pities her and takes her away, leaving another deer in her place.

Artemis was one of the most widely venerated of the Ancient Greek deities, her worship spread throughout ancient Greece, with her multiple temples, altars, shrines, and local veneration found everywhere in the ancient world. Her great temple at Ephesus was one of the Seven Wonders of the Ancient World, before it was burnt to the ground. Artemis' symbols included a bow and arrow, a quiver, and hunting knives, and the deer and the cypress were sacred to her. Diana, her Roman equivalent, was especially worshipped on the Aventine Hill in Rome, near Lake Nemi in the Alban Hills, and in Campania.",
                    VideoUrl = "https://www.youtube.com/watch?v=q09FTbnuC8I",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Ares",
                    ImageUrl = "https://www.theoi.com/image/K9.6Ares.jpg",
                    Description = @"Ares (/ˈɛəriːz/; Ancient Greek: Ἄρης, Árēs [árɛːs]) is the Greek god of courage and war. He is one of the Twelve Olympians, and the son of Zeus and Hera. The Greeks were ambivalent toward him. He embodies the physical valor necessary for success in war but can also personify sheer brutality and bloodlust, in contrast to his sister, the armored Athena, whose martial functions include military strategy and generalship. An association with Ares endows places, objects, and other deities with a savage, dangerous, or militarized quality.

Although Ares' name shows his origins as Mycenaean, his reputation for savagery was thought by some to reflect his likely origins as a Thracian deity. Some cities in Greece and several in Asia Minor held annual festivals to bind and detain him as their protector. In parts of Asia Minor, he was an oracular deity. Still further away from Greece, the Scythians were said to ritually kill one in a hundred prisoners of war as an offering to their equivalent of Ares. The later belief that ancient Spartans had offered human sacrifice to Ares may owe more to mythical prehistory, misunderstandings, and reputation than to reality.

Though there are many literary allusions to Ares' love affairs and children, he has a limited role in Greek mythology. When he does appear, he is often humiliated. In the Trojan War, Aphrodite, protector of Troy, persuades Ares to take the Trojan's side. The Trojans lose, while Ares' sister Athena helps the Greeks to victory. Most famously, when the craftsman-god Hephaestus discovers his wife Aphrodite is having an affair with Ares, he traps the lovers in a net and exposes them to the ridicule of the other gods.

Ares' nearest counterpart in Roman religion is Mars, who was given a more important and dignified place in ancient Roman religion as ancestral protector of the Roman people and state. During the Hellenization of Latin literature, the myths of Ares were reinterpreted by Roman writers under the name of Mars, and in later Western art and literature, the mythology of the two figures became virtually indistinguishable.",
                    VideoUrl = "https://www.youtube.com/watch?v=D2pGMViJlVA",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Apollo",
                    ImageUrl = "https://www.theoi.com/image/K5.16Apollon.jpg",
                    Description = @"Apollo is one of the Olympian deities in classical Greek and Roman religion and Greek and Roman mythology. The national divinity of the Greeks, Apollo has been recognized as a god of archery, music and dance, truth and prophecy, healing and diseases, the Sun and light, poetry, and more. One of the most important and complex of the Greek gods, he is the son of Zeus and Leto, and the twin brother of Artemis, goddess of the hunt. Seen as the most beautiful god and the ideal of the kouros (ephebe, or a beardless, athletic youth), Apollo is considered to be the most Greek of all the gods.[citation needed] Apollo is known in Greek-influenced Etruscan mythology as Apulu.

As the patron deity of Delphi (Apollo Pythios), Apollo is an oracular god—the prophetic deity of the Delphic Oracle. Apollo is the god who affords help and wards off evil; various epithets call him the ""averter of evil"". Delphic Apollo is the patron of seafarers, foreigners and the protector of fugitives and refugees.

Medicine and healing are associated with Apollo, whether through the god himself or mediated through his son Asclepius. Apollo delivered people from epidemics, yet he is also a god who could bring ill-health and deadly plague with his arrows. The invention of archery itself is credited to Apollo and his sister Artemis. Apollo is usually described as carrying a golden bow and a quiver of silver arrows. Apollo's capacity to make youths grow is one of the best attested facets of his panhellenic cult persona. As a protector of the young (kourotrophos), Apollo is concerned with the health and education of children. He presided over their passage into adulthood. Long hair, which was the prerogative of boys, was cut at the coming of age (ephebeia) and dedicated to Apollo.

Apollo is an important pastoral deity, and was the patron of herdsmen and shepherds. Protection of herds, flocks and crops from diseases, pests and predators were his primary duties. On the other hand, Apollo also encouraged founding new towns and establishment of civil constitution. He is associated with dominion over colonists. He was the giver of laws, and his oracles were consulted before setting laws in a city.

As the god of mousike, Apollo presides over all music, songs, dance and poetry. He is the inventor of string-music, and the frequent companion of the Muses, functioning as their chorus leader in celebrations. The lyre is a common attribute of Apollo. In Hellenistic times, especially during the 5th century BCE, as Apollo Helios he became identified among Greeks with Helios, the personification of the Sun. In Latin texts, however, there was no conflation of Apollo with Sol among the classical Latin poets until 1st century CE. Apollo and Helios/Sol remained separate beings in literary and mythological texts until the 5th century CE.",
                    VideoUrl = "https://www.youtube.com/watch?v=695TunhNpuw",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Aphrodite",
                    ImageUrl = "https://www.theoi.com/image/K10.3BAphrodite.jpg",
                    Description = @"Aphrodite (/ˌæfrəˈdaɪtiː/ (listen) AF-rə-DY-tee; Ancient Greek: Ἀφροδίτη, romanized: Aphrodítē; Attic Greek pronunciation: [a.pʰro.dǐː.tɛː], Koine Greek: [a.ɸroˈdi.te̝], Modern Greek: [a.froˈði.ti]) is an ancient Greek goddess associated with love, lust, beauty, pleasure, passion and procreation. She was syncretized with the Roman goddess Venus. Aphrodite's major symbols include myrtles, roses, doves, sparrows, and swans. The cult of Aphrodite was largely derived from that of the Phoenician goddess Astarte, a cognate of the East Semitic goddess Ishtar, whose cult was based on the Sumerian cult of Inanna. Aphrodite's main cult centers were Cythera, Cyprus, Corinth, and Athens. Her main festival was the Aphrodisia, which was celebrated annually in midsummer. In Laconia, Aphrodite was worshipped as a warrior goddess. She was also the patron goddess of prostitutes, an association which led early scholars to propose the concept of ""sacred prostitution"" in Greco-Roman culture, an idea which is now generally seen as erroneous.

In Hesiod's Theogony, Aphrodite is born off the coast of Cythera from the foam (ἀφρός, aphrós) produced by Uranus's genitals, which his son Cronus had severed and thrown into the sea. In Homer's Iliad, however, she is the daughter of Zeus and Dione. Plato, in his Symposium 180e, asserts that these two origins actually belong to separate entities: Aphrodite Ourania (a transcendent, ""Heavenly"" Aphrodite) and Aphrodite Pandemos (Aphrodite common to ""all the people""). Aphrodite had many other epithets, each emphasizing a different aspect of the same goddess, or used by a different local cult. Thus she was also known as Cytherea (Lady of Cythera) and Cypris (Lady of Cyprus), because both locations claimed to be the place of her birth.

In Greek mythology, Aphrodite was married to Hephaestus, the god of fire, blacksmiths and metalworking. Aphrodite was frequently unfaithful to him and had many lovers; in the Odyssey, she is caught in the act of adultery with Ares, the god of war.In the First Homeric Hymn to Aphrodite, she seduces the mortal shepherd Anchises. Aphrodite was also the surrogate mother and lover of the mortal shepherd Adonis, who was killed by a wild boar.Along with Athena and Hera, Aphrodite was one of the three goddesses whose feud resulted in the beginning of the Trojan War and she plays a major role throughout the Iliad.Aphrodite has been featured in Western art as a symbol of female beauty and has appeared in numerous works of Western literature.She is a major deity in modern Neopagan religions, including the Church of Aphrodite, Wicca, and Hellenismos.",
                    VideoUrl = "https://www.youtube.com/watch?v=63aEypTlvKw",
                    Type = Enum.Parse<DeityType>("God"),
                },
                new GreekDeity
                {
                    Name = "Atlas",
                    ImageUrl = "https://www.theoi.com/image/T20.1Atlas.jpg",
                    Description = @"In Greek mythology, Atlas (/ˈætləs/; Greek: Ἄτλας, Átlas) is a Titan condemned to hold up the heavens or sky for eternity after the Titanomachy. Atlas also plays a role in the myths of two of the greatest Greek heroes: Heracles (Hercules in Roman mythology) and Perseus. According to the ancient Greek poet Hesiod, Atlas stood at the ends of the earth in extreme west. Later, he became commonly identified with the Atlas Mountains in northwest Africa and was said to be the first King of Mauretania. Atlas was said to have been skilled in philosophy, mathematics, and astronomy. In antiquity, he was credited with inventing the first celestial sphere. In some texts, he is even credited with the invention of astronomy itself.

Atlas was the son of the Titan Iapetus and the Oceanid Asia or Clymene. He was a brother of Epimetheus and Prometheus. He had many children, mostly daughters, the Hesperides, the Hyades, the Pleiades, and the nymph Calypso who lived on the island Ogygia.

The term Atlas has been used to describe a collection of maps since the 16th century when Flemish geographer Gerardus Mercator published his work in honour of the mythological Titan.

The ""Atlantic Ocean"" is derived from ""Sea of Atlas"". The name of Atlantis mentioned in Plato's Timaeus' dialogue derives from ""Atlantis nesos"" (Ancient Greek: Ἀτλαντὶς νῆσος), literally meaning ""Atlas's Island.""",
                    VideoUrl = "https://www.youtube.com/watch?v=aLOFvUf9VCc",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Cronus",
                    ImageUrl = "https://www.theoi.com/image/T6.1BKronos.jpg",
                    Description = @"In Greek mythology, Cronus, Cronos, or Kronos (/ˈkroʊnəs/ or /ˈkroʊnɒs/, from Greek: Κρόνος, Krónos) was the leader and youngest of the first generation of Titans, the divine descendants of the primordial Gaia (Mother Earth) and Uranus (Father Sky). He overthrew his father and ruled during the mythological Golden Age, until he was overthrown by his own son Zeus and imprisoned in Tartarus. According to Plato, however, the deities Phorcys, Cronus, and Rhea were the eldest children of Oceanus and Tethys.

Cronus was usually depicted with a harpe, scythe or a sickle, which was the instrument he used to castrate and depose Uranus, his father. In Athens, on the twelfth day of the Attic month of Hekatombaion, a festival called Kronia was held in honour of Cronus to celebrate the harvest, suggesting that, as a result of his association with the virtuous Golden Age, Cronus continued to preside as a patron of the harvest. Cronus was also identified in classical antiquity with the Roman deity Saturn.",
                    VideoUrl = "https://www.youtube.com/watch?v=WqVoX2f2h7U",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Mnemosyne",
                    ImageUrl = "https://www.theoi.com/image/img_mnemosyne.jpg",
                    Description = @"Mnemosyne, in Greek mythology, the goddess of memory. A Titaness, she was the daughter of Uranus (Heaven) and Gaea (Earth), and, according to Hesiod, the mother (by Zeus) of the nine Muses. She gave birth to the Muses after Zeus went to Pieria and stayed with her nine consecutive nights.",
                    VideoUrl = "https://www.youtube.com/watch?v=xliDJCBxHAo",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Oceanus",
                    ImageUrl = "https://www.theoi.com/image/Z35.1Okeanos.jpg",
                    Description = @"Oceanus, in Greek mythology, the river that flowed around the Earth (conceived as flat), for example, in the shield of Achilles described in Homer’s Iliad, Book XVIII. Beyond it, to the west, were the sunless land of the Cimmerii, the country of dreams, and the entrance to the underworld. In Hesiod’s Theogony, Oceanus was the oldest Titan, the son of Uranus (Heaven) and Gaea (Earth), the husband of the Titan Tethys, and father of 3,000 stream spirits and 3,000 ocean nymphs. In the Iliad, Book XIV, Oceanus is identified once as the begetter of the gods and once as the begetter of all things; although the comments were isolated, they were influential in later thinking. Oceanus also appears in Aeschylus’s Prometheus Bound.",
                    VideoUrl = "https://www.youtube.com/watch?v=EAyFZ3E30dA",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Prometheus",
                    ImageUrl = "https://www.theoi.com/image/T20.1Prometheus.jpg",
                    Description = @"In Greek mythology, Prometheus (/prəˈmiːθiəs/; Ancient Greek: Προμηθεύς, [promɛːtʰéu̯s], possibly meaning ""forethought"") is a Titan god of fire. Prometheus is best known for defying the gods by stealing fire from them and giving it to humanity in the form of technology, knowledge, and more generally, civilization. In some versions of the myth he is also credited with the creation of humanity from clay. Prometheus is known for his intelligence and for being a champion of humankind, and is also generally seen as the author of the human arts and sciences. He is sometimes presented as the father of Deucalion, the hero of the flood story.

The punishment of Prometheus as a consequence of the theft of fire and giving it to humans is a popular subject of both ancient and modern culture. Zeus, king of the Olympian gods, sentenced Prometheus to eternal torment for his transgression. Prometheus was bound to a rock, and an eagle—the emblem of Zeus—was sent to eat his liver (in ancient Greece, the liver was thought to be the seat of human emotions). His liver would then grow back overnight, only to be eaten again the next day in an ongoing cycle. According to several major versions of the myth, most notably that of Hesiod, Prometheus was eventually freed by the hero Heracles. In yet more symbolism, the struggle of Prometheus is located by some at Mount Elbrus or at Mount Kazbek, two volcanic promontories in the Caucasus Mountains beyond which for the ancient Greeks lay the realm of the barbarii.

In another myth, Prometheus establishes the form of animal sacrifice practiced in ancient Greek religion. Evidence of a cult to Prometheus himself is not widespread. He was a focus of religious activity mainly at Athens, where he was linked to Athena and Hephaestus, who were the Greek deities of creative skills and technology.

In the Western classical tradition, Prometheus became a figure who represented human striving (particularly the quest for scientific knowledge) and the risk of overreaching or unintended consequences. In particular, he was regarded in the Romantic era as embodying the lone genius whose efforts to improve human existence could also result in tragedy: Mary Shelley, for instance, gave The Modern Prometheus as the subtitle to her novel Frankenstein (1818).",
                    VideoUrl = "https://www.youtube.com/watch?v=AbCIbBz4SkI",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Rhea",
                    ImageUrl = "https://www.theoi.com/image/T6.1CRhea.jpg",
                    Description = @"RHEIA (Rhea) was the Titanis (Titaness) mother of the gods, and goddess of female fertility, motherhood, and generation. Her name means ""flow"" and ""ease."" As the wife of Kronos (Cronus, Time), she represented the eternal flow of time and generations; as the great Mother (Meter Megale), the ""flow"" was menstrual blood, birth waters, and milk. She was also a goddess of comfort and ease, a blessing reflected in the common Homeric phrase ""the gods who live at their ease (rhea).""

In myth, Rhea was the wife of the Titan Kronos (Cronus) and Queen of Heaven. When her husband heard a prophecy that he would be deposed by one of his children, he took to swallowing each of them as soon as they were born. But Rhea bore her youngest, Zeus, in secret and hid him away in a cave in Krete (Crete) guarded by shield-clashing Kouretes (Curetes). In his stead she presented Kronos with a stone wrapped in swaddling clothes which he promptly devoured.

Rhea was closely identified with the Anatolian mother-goddess Kybele (Cybele). They were both depicted as matronly women, usually wearing a turret crown, and attended by lions.
",
                    VideoUrl = "https://www.youtube.com/watch?v=G8IpOkPKYfU",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Tethys",
                    ImageUrl = "https://www.theoi.com/image/Z35.5BTethys.jpg",
                    Description = @"TETHYS was the Titan goddess of the primal font of fresh water which nourishes the earth. She was the wife of Okeanos (Oceanus), the earth-encircling, fresh-water stream, and the mother of the Potamoi (Rivers), the Okeanides (Oceanids) (nymphs of springs, streams and fountains), and the Nephelai (Clouds). Tethys, daughter of Gaia (Earth), fed her children's springs with the waters of Okeanos drawn through subterranean acquifers. Her name was derived from the Greek word têthê meaning ""nurse"" or ""grandmother"".

In Greek vase painting Tethys appears as an unremarkable woman accompanied by Eileithyia, goddess of childbirth, and her fish-tailed husband Okeanos. In mosaic art she was depicted with a small pair of wings on her brow which probably signified her role of mother of rain-couds.

Tethys was perhaps identified with the Titanis Eurynome, one-time Queen of Heaven, who was cast into the Ocean-stream along with her husband Ophion by Kronos (Cronus). She was probably also connected with the Protogenos Thesis (Mother Creation) who appears in the Orphic cosmogony. Tethys was described by late classical poets as the sea personified and was equated with Thalassa.
",
                    VideoUrl = "https://www.youtube.com/watch?v=-sZcVcjUPJ4",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
                new GreekDeity
                {
                    Name = "Themis",
                    ImageUrl = "https://www.theoi.com/image/T8.1BThemis.jpg",
                    Description = @"THEMIS was the Titan goddess of divine law and order--the traditional rules of conduct first established by the gods. She was also a prophetic goddess who presided over the most ancient oracles, including Delphoi (Delphi). In this role, she was the divine voice (themistes) who first instructed mankind in the primal laws of justice and morality, such as the precepts of piety, the rules of hospitality, good governance, conduct of assembly, and pious offerings to the gods. In Greek, the word themis referred to divine law, those rules of conduct long established by custom. Unlike the word nomos, the term was not usually used to describe laws of human decree.

Themis was an early bride of Zeus and his first counsellor. She was often represented seated beside his throne advising him on the precepts of divine law and the rules of fate.

Themis was closely identified with Demeter Thesmophoros (""Bringer of Law""). Indeed Themis' six children, the spring-time Horai (Horae, Seasons) and death-bringing Moirai (Moirae, Fates), reflect the dual-functions of Demeter's own daughter Persephone. Themis was also identified with Gaia (Gaea, Earth) especially in the role of the oracular voice of earth.

",
                    VideoUrl = "https://www.youtube.com/watch?v=EdANcFlYFBU",
                    Type = Enum.Parse<DeityType>("Titan"),
                },
            };

            foreach (var item in greekDeities)
            {
                await dbContext.GreekDeities.AddAsync(new GreekDeity
                {
                    Id = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    VideoUrl = item.VideoUrl,
                    Description = item.Description,
                    Type = item.Type,
                });
            }
        }
    }
}
