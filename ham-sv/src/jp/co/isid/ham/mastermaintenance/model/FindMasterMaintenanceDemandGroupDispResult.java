package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ������O���[�v�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceDemandGroupDispResult extends AbstractServiceResult
{
    /** ������O���[�v�����f�[�^VO */
    private FindMbj26BillGroupVO _demandGroupVO = null;

    /** HC���匟���f�[�^VO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /**
     * ������O���[�v�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _demandGroupVO
     */
    public void setDemandGroupVO(FindMbj26BillGroupVO vo)
    {
        _demandGroupVO = vo;
    }

    /**
     * ������O���[�v�����f�[�^VO���擾���܂�
     * @return _demandGroupVO
     */
    public FindMbj26BillGroupVO getDemandGroupVO()
    {
        return _demandGroupVO;
    }

    /**
     * HC���匟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _hCSectionVO
     */
    public void setHCSectionVO(FindMbj06HcBumonVO vo)
    {
        _hCSectionVO = vo;
    }

    /**
     * HC���匟���f�[�^VO���擾���܂�
     * @return _hCSectionVO
     */
    public FindMbj06HcBumonVO getHCSectionVO()
    {
        return _hCSectionVO;
    }

}
