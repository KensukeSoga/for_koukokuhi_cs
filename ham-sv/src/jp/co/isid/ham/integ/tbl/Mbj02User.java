package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * �S���҃}�X�^
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj02User {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj02User() {
    }

    /** �S���҃}�X�^ (MBJ02USER) */
    public static final String TBNAME = "MBJ02USER";

    /** Prefix (MBJ02_) */
    public static final String PREFIX = "MBJ02_";

    /** �S����ID (HAMID) */
    public static final String HAMID = PREFIX + "HAMID";

    /** �S���Ґ� (USERNAME1) */
    public static final String USERNAME1 = PREFIX + "USERNAME1";

    /** �S���Җ� (USERNAME2) */
    public static final String USERNAME2 = PREFIX + "USERNAME2";

    /** ���[�U��� (USERTYPE) */
    public static final String USERTYPE = PREFIX + "USERTYPE";

    /** �f�[�^�X�V���� (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** �f�[�^�X�V�� (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** �X�V�v���O���� (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** �X�V�S����ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
