package jp.co.isid.ham.billing.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj05EstimateItemVO;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC�}�̔�쐬�o�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/5/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RegisterOutputFileInfoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ψČ� */
    private List<Tbj05EstimateItemVO> _estimateItem = null;


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegisterOutputFileInfoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new RegisterOutputFileInfoVO();
    }

    /**
     * ���ψČ����擾���܂�
     *
     * @return ���ψČ�
     */
    public List<Tbj05EstimateItemVO> getEstimateItem() {
        return _estimateItem;
    }

    /**
     * ���ψČ���ݒ肵�܂�
     *
     * @param estimateItem ���ψČ�
     */
    public void setEstimateItem(List<Tbj05EstimateItemVO> estimateItem) {
        _estimateItem = estimateItem;
    }

}
