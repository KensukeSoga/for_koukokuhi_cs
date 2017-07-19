package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC���i�I����������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/26 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionResult extends AbstractServiceResult {

    /** HC���i�I�� */
    List<FindHCItemSelectionVO> _hcItemSelection;


    /**
     * HC���i�I�����擾����
     *
     * @return HC���i�I��
     */
    public List<FindHCItemSelectionVO> getHCItemSelection() {
        return _hcItemSelection;
    }

    /**
     * HC���i�I����ݒ肷��
     *
     * @param hcItemSelection HC���i�I��
     */
    public void setHCItemSelection(List<FindHCItemSelectionVO> hcItemSelection) {
        _hcItemSelection = hcItemSelection;
    }

}
