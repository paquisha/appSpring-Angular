package ec.com.aekmot.awsImageupload.bucket;

public enum BucketName {
    PROFILE_IMAGE("aekmot-image-upload-123");

    private final String bucketName;

    BucketName(String bucketName){
        this.bucketName = bucketName;
    }

    public String getBucketName() {
        return bucketName;
    }
}
