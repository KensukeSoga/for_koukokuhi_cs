package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �o���g�D�W�J�e�[�u���\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/05/02 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMEU07SIKKRSPRDDispResult extends AbstractServiceResult
{
    /** �o���g�D�W�J�e�[�u�������f�[�^VO */
    private FindMasterMaintenanceMEU07SIKKRSPRDVO _MEU07SIKKRSPRDVO = null;

    /**
     * �o���g�D�W�J�e�[�u�������f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _MEU07SIKKRSPRDVO
     */
    public void setMEU07SIKKRSPRDVO(FindMasterMaintenanceMEU07SIKKRSPRDVO vo)
    {
        _MEU07SIKKRSPRDVO = vo;
    }

    /**
     * �o���g�D�W�J�e�[�u�������f�[�^VO���擾���܂�
     * @return _MEU07SIKKRSPRDVO
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDVO getMEU07SIKKRSPRDVO()
    {
        return _MEU07SIKKRSPRDVO;
    }

}
