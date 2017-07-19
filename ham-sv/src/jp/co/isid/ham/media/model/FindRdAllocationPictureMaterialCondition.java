package jp.co.isid.ham.media.model;

import java.io.Serializable;

/**
 * <P>
 * ���W�I��AllocationPicture�f�ޏ�񌟍�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureMaterialCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �N�� */
    private String _yearMonth = null;

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

}