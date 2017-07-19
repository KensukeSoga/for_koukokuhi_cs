package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC�S���ҕ\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCUserDispResult extends AbstractServiceResult
{
    /** HC�S���Ҍ����f�[�^VO */
    private FindMbj07HcUserVO _hCUserVO = null;

    /** HC���匟���f�[�^VO */
    private FindMbj06HcBumonVO _hCSectionVO = null;

    /**
     * HC�S���Ҍ����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _hCUserVO
     */
    public void setHCUserVO(FindMbj07HcUserVO vo)
    {
        _hCUserVO = vo;
    }

    /**
     * HC�S���Ҍ����f�[�^VO���擾���܂�
     * @return _hCUserVO
     */
    public FindMbj07HcUserVO getHCUserVO()
    {
        return _hCUserVO;
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
