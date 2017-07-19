package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �ݒ�Ǖ\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceEstablishmentOfficeDispResult extends AbstractServiceResult
{
    /** �ݒ�ǌ����f�[�^VO */
    private FindMbj29SetteiKykVO _establishmentOfficeVO = null;

    /**
     * �ݒ�ǌ����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _establishmentOfficeVO
     */
    public void setEstablishmentOfficeVO(FindMbj29SetteiKykVO vo)
    {
        _establishmentOfficeVO = vo;
    }

    /**
     * �ݒ�ǌ����f�[�^VO���擾���܂�
     * @return _establishmentOfficeVO
     */
    public FindMbj29SetteiKykVO getEstablishmentOfficeVO()
    {
        return _establishmentOfficeVO;
    }

}
