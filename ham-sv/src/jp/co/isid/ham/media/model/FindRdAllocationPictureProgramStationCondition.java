package jp.co.isid.ham.media.model;

import java.io.Serializable;

/**
 * <P>
 * ���W�I��AllocationPicture�ԑg�l�b�g�Ǐ�񌟍�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureProgramStationCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �o�͑Ώ� */
    private String _rdSeqNo = null;

    /**
     * �o�͑Ώۂ��擾����
     * @return String �o�͑Ώ�
     */
    public String getRdSeqNo() {
        return _rdSeqNo;
    }

    /**
     * �o�͑Ώۂ�ݒ肷��
     * @param val String �o�͑Ώ�
     */
    public void setRdSeqNo(String val) {
        _rdSeqNo = val;
    }

}