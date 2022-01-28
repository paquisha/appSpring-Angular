package ec.com.aekmot.awsImageupload.filestore;

import com.amazonaws.AmazonServiceException;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.model.ObjectMetadata;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.InputStream;
import java.util.*;

@Service
public class FileStrore {
    private final AmazonS3 s3;

    @Autowired
    public FileStrore(AmazonS3 s3){
        this.s3 = s3;
    }

    public void save(String path,
                     String fileName,
                     Optional<Map<String, String>> optionalMetadata,
                     InputStream inputStream){

        ObjectMetadata metadata = new ObjectMetadata();
        optionalMetadata.ifPresent(map -> {
            if(!map.isEmpty()){
                map.forEach(metadata::addUserMetadata);
            }
        });
        try{
            s3.putObject(path, fileName, inputStream, metadata);
        }catch(AmazonServiceException ex){
            throw new IllegalStateException("Faild to store file to s3", ex);
        }
    }
}
