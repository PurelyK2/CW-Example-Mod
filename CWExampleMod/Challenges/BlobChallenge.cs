using CWAPI.Challenges;
using CWExampleMod.Items;
using CWExampleMod.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWExampleMod.Challenges;

public class BlobChallenge : ModdedChallenge
{
    public BlobChallenge()
    {
        ChallengeName = "BLOB";
        Description = "BLOBS SHALL CONSUME THE WORLD!!!";
    }

    public override Type ChallengeUnlock => typeof(Mitosis);
}
