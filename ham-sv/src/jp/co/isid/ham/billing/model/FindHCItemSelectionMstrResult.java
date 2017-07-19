package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC���i�I���}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionMstrResult extends AbstractServiceResult {

    /** ��ʍ��ڕ\���񐧌�}�X�^ */
    List<Mbj37DisplayControlVO> _dc;

    /** HC���i�}�X�^ */
    List<FindHCProductVO> _product;


    /**
     * ��ʍ��ڕ\���񐧌�}�X�^���擾����
     *
     * @return ��ʍ��ڕ\���񐧌�}�X�^
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^��ݒ肷��
     *
     * @param dc ��ʍ��ڕ\���񐧌�}�X�^
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /**
     * HC���i�}�X�^���擾����
     *
     * @return HC���i�}�X�^
     */
    public List<FindHCProductVO> getProduct() {
        return _product;
    }

    /**
     * HC���i�}�X�^��ݒ肷��
     *
     * @param product HC���i�}�X�^
     */
    public void setProduct(List<FindHCProductVO> product) {
        _product = product;
    }

}
