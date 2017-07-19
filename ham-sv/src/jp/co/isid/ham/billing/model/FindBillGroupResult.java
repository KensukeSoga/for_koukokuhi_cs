package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ������O���[�v��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindBillGroupResult extends AbstractServiceResult {

    /** ������O���[�v */
    List<Mbj26BillGroupVO> _bg;

    /**
     * ������O���[�v���擾
     * @return
     */
    public List<Mbj26BillGroupVO> getBillGroup() {
        return _bg;
    }

    /**
     * ������O���[�v��ݒ�
     * @param bg
     */
    public void setBillGroup(List<Mbj26BillGroupVO> bg) {
        this._bg = bg;
    }
}
