package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;
/**
 * <P>
 * �����捞VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/2 J.Kamiyama)<BR>
 * </P>
 * @author J.Kamiyama
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class CheckBillProductionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �f�[�^�� */
    private BigDecimal _DATACOUNT = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public CheckBillProductionVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new CheckBillProductionVO();
    }

    /**
     * �f�[�^�����擾����
     *
     * @return �f�[�^��
     */
    public BigDecimal getDATACOUNT()
    {
        return _DATACOUNT;
    }

    /**
     * �f�[�^����ݒ肷��
     *
     * @param val �f�[�^��
     */
    public void setDATACOUNT(BigDecimal val)
    {
        _DATACOUNT = val;
    }

}
