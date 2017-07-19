package jp.co.isid.ham.media.model;

import java.io.Serializable;

/**
 * <P>
 * ���W�I��AllocationPicture��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �N�� */
    private String _yearMonth = null;

    /** �o�͑Ώ� */
    private String _rdSeqNo = null;

    /**
     * �N�����擾����
     * @return String �N��
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * �N����ݒ肷��
     * @param val String �N��
     */
    public void setYearMonth(String val) {
        _yearMonth = val;
    }

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