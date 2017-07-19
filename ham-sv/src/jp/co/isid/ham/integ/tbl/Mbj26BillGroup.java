package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * �����O���[�v�}�X�^
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj26BillGroup {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj26BillGroup() {
    }

    /** �����O���[�v�}�X�^ (MBJ26BILLGROUP) */
    public static final String TBNAME = "MBJ26BILLGROUP";

    /** Prefix (MBJ26_) */
    public static final String PREFIX = "MBJ26_";

    /** �O���[�v�R�[�h (GROUPCD) */
    public static final String GROUPCD = PREFIX + "GROUPCD";

    /** �O���[�v�� (GROUPNM) */
    public static final String GROUPNM = PREFIX + "GROUPNM";

    /** �O���[�v��(���[) (GROUPNMRPT) */
    public static final String GROUPNMRPT = PREFIX + "GROUPNMRPT";

    /** �\�[�gNO (SORTNO) */
    public static final String SORTNO = PREFIX + "SORTNO";

    /** HC����R�[�h (HCBUMONCD) */
    public static final String HCBUMONCD = PREFIX + "HCBUMONCD";

    /** HC����R�[�h(Fee�Č������p) (HCBUMONCDBILL) */
    public static final String HCBUMONCDBILL = PREFIX + "HCBUMONCDBILL";

    /** �f�[�^�X�V���� (UPDDATE) */
    public static final String UPDDATE = PREFIX + "UPDDATE";

    /** �f�[�^�X�V�� (UPDNM) */
    public static final String UPDNM = PREFIX + "UPDNM";

    /** �X�V�v���O���� (UPDAPL) */
    public static final String UPDAPL = PREFIX + "UPDAPL";

    /** �X�V�S����ID (UPDID) */
    public static final String UPDID = PREFIX + "UPDID";

}
