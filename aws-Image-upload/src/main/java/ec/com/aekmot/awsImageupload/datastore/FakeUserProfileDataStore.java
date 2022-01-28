package ec.com.aekmot.awsImageupload.datastore;

import ec.com.aekmot.awsImageupload.profile.UserProfile;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class FakeUserProfileDataStore {
    private static final List<UserProfile> USER_PROFILE = new ArrayList<>();

    static{
        USER_PROFILE.add(new UserProfile(UUID.randomUUID(), "ginaaime", null));
        USER_PROFILE.add(new UserProfile(UUID.randomUUID(), "amaruhakan", null));
    }

    public List<UserProfile> getUserProfile(){
        return USER_PROFILE;
    }
}
