package ec.com.aekmot.awsImageupload.profile;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserProfileService {
    private final UserProfiledataAccessService userProfiledataAccessService;

    @Autowired
    public UserProfileService(UserProfiledataAccessService userProfiledataAccessService){
        this.userProfiledataAccessService = userProfiledataAccessService;
    }

    List<UserProfile> getuserprofile(){
        return userProfiledataAccessService.getUserProfiles();
    }
}
